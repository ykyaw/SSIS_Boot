using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RequisitionDetailRepo
    {
        private SSISContext dbcontext;
        public RequisitionDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public RequisitionDetail updateretrievalid(RequisitionDetail rd)
        {
            dbcontext.RequisitionDetails.Update(rd);
            dbcontext.SaveChanges();
            //dbcontext.RequisitionDetails.Find(rd.Id);
            return dbcontext.RequisitionDetails.Include(m => m.Requisition)
                .Include(m => m.Product)
                .Include(m => m.Retrieval)
                .Include(m => m.Retrieval).FirstOrDefault(x => x.Id == rd.Id);
        }

        public List<RequisitionDetail> retrievedisbursementlist(string deptId, long collectiondate)
        {
            List<RequisitionDetail> dlist = dbcontext.RequisitionDetails.Include(m => m.Requisition).Include(m => m.Product)
                .Include(m => m.Retrieval).Where(m => m.Requisition.DepartmentId == deptId && m.Requisition.CollectionDate == collectiondate).ToList();
            return dlist;
        }
        public bool updaterequsitiondetail(RequisitionDetail rd)
        {
            try
            {
                var original = dbcontext.RequisitionDetails.Find(rd.Id);
                if(original == null)
                {
                    throw new Exception();
                }
                original.QtyDisbursed = rd.QtyDisbursed;
                original.DisburseRemark = rd.DisburseRemark;
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error saving Requsition Detail for " + rd.Product.Description);
            }
        }
        public bool addreqformitem(RequisitionDetail rd)
        {
            dbcontext.RequisitionDetails.Add(rd);
            dbcontext.SaveChanges();
            return true;
        }

        public bool deleteRequisitionDetailByRequisitionId(RequisitionDetail rd)
        {
            RequisitionDetail original = dbcontext.RequisitionDetails.Where(m => m.RequisitionId == rd.RequisitionId).FirstOrDefault();
            if (original != null)
            {
                dbcontext.RequisitionDetails.Remove(original);
            }
            dbcontext.SaveChanges();
            return true;
        }

        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate)
        {
            Requisition rq = dbcontext.Requisitions.Where(m => m.DepartmentId == deptid && m.CollectionDate == longdate).FirstOrDefault();
            List<RequisitionDetail> rdl = dbcontext.RequisitionDetails.Where(m=>m.RequisitionId == rq.Id).ToList();
            return rdl;
        }


        public bool EmpAckItemReceived(RequisitionDetail rd)
        {
            try
            {
                RequisitionDetail original = dbcontext.RequisitionDetails.Where(m => m.Id == rd.Id).FirstOrDefault();
                if (original != null)
                {
                    original.QtyReceived = rd.QtyReceived;
                    original.RepRemark = rd.RepRemark;
                }
            }
            catch
            {
                throw new Exception("Error updating receival on Requisition Detail ");
            }
            dbcontext.SaveChanges();
            return true;
        }

        public bool ClerkSaveRequisitionDetailRemarksOnCompletion(RequisitionDetail rd)
        {
            try
            {
                RequisitionDetail original = dbcontext.RequisitionDetails.Where(m => m.Id == rd.Id).FirstOrDefault();
                if (original != null)
                {
                    original.ClerkRemark = rd.ClerkRemark;
                }
            }
            catch
            {
                throw new Exception("Error completing requisition for " + rd.Product.Description);
            }
            dbcontext.SaveChanges();
            return true;
        }

    }
}

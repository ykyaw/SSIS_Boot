using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RequisitionRepo
    {
        private SSISContext dbcontext;
        public RequisitionRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Requisition findreqformByReqID (int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m => m.RequisitionDetails).ThenInclude(m => m.Product)
                .Include(m => m.Department).Where(m => m.Id == reqId).FirstOrDefault();
            return req;
        }

        public List<Requisition> findallreqform() //not loading properly. maybe too much info. need to relook
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails).
        }

        public List<Requisition> findreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).Where(m => m.DepartmentId == deptID).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails)
        }
        public List<Requisition> findrequsitionbycollectiondate(long date)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product).Include(m=>m.Department).Where(m => m.CollectionDate == date).ToList();
            return lr;
        }

        public Requisition findreqByReqId(int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m => m.RequisitionDetails).ThenInclude(m => m.Product).Include(m => m.Department).FirstOrDefault(m => m.Id == reqId);
            return req;
        }

        //check for deptemp create of requisition form
        //public bool updatereqformitem(RequisitionDetail rd)
        //{
        //    var original = dbcontext.RequisitionDetails.Find(rd.Id);
        //    if (original == null)
        //    {
        //        throw new Exception();
        //    }
        //    dbcontext.Entry(original).CurrentValues.SetValues(rd);
        //    dbcontext.SaveChanges();
        //    return true;
        //}

        public bool updaterequisitioncollectiontime(Requisition r1)
        {
            try
            {
                var original = dbcontext.Requisitions.Find(r1.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                dbcontext.Entry(original).CurrentValues.SetValues(r1);
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error updating collection time for retrieval");
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.Common;
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

        public Requisition findreqformByReqID(int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m => m.RequisitionDetails).ThenInclude(m => m.Product)
                .Include(m => m.Department).Include(m => m.ReqByEmp).Include(m => m.CollectionPoint).Include(m => m.ApprovedBy).Include(m=>m.ReceivedByRep).Where(m => m.Id == reqId).FirstOrDefault();
            return req;
        }

        public List<Requisition> findallreqform() //not loading properly. maybe too much info. need to relook
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).Include(m => m.CollectionPoint).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails).
        }

        public List<Requisition> findreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.CollectionPoint)
                .Include(m => m.ReceivedByRep)
                .Where(m => m.DepartmentId == deptID).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails)
        }

        public List<Requisition> finddisbursementByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.ReceivedByRep)
                .Include(m => m.CollectionPoint)
                .Where(m => m.DepartmentId == deptID)
                .Where(m=>m.Status == Status.RequsitionStatus.confirmed || m.Status == Status.RequsitionStatus.received || m.Status == Status.RequsitionStatus.completed).ToList();
            return lr;
        }

        public List<Requisition> findrequsitionbycollectiondateandstatus(long date, int clerkid, string reqStatus)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.RequisitionDetails)
                .ThenInclude(m => m.Product)
                .Include(m => m.CollectionPoint)
                .Include(m => m.Department)
                .Include(m => m.ReceivedByRep)
                .Where(m => m.CollectionDate == date && m.ProcessedByClerkId == clerkid && m.Status == reqStatus).ToList();
            return lr;
        }

        public Requisition findreqByReqId(int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m=>m.CollectionPoint).Include(m => m.RequisitionDetails).ThenInclude(m => m.Product).Include(m => m.ReceivedByRep)
                .Include(m => m.ReqByEmp).Include(m => m.Department).Include(m=>m.CollectionPoint).FirstOrDefault(m => m.Id == reqId);
            return req;
        }

        public Requisition saveNewRequisition(Requisition req)
        {
            dbcontext.Requisitions.Add(req);
            dbcontext.SaveChanges();
            return req;
        }

        public Requisition updaterequisitioncollectiontime(Requisition r1)
        {
            try
            {
                var original = dbcontext.Requisitions.Include(m=>m.Department).Include(m=>m.CollectionPoint).Include(m=>m.ReceivedByRep).FirstOrDefault(m=>m.Id == r1.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                original.CollectionDate = r1.CollectionDate;
                original.Status = r1.Status;
                original.ProcessedByClerkId = r1.ProcessedByClerkId;
                //dbcontext.Entry(original).CurrentValues.SetValues(r1);
                dbcontext.SaveChanges();
                return original;
            }
            catch
            {
                throw new Exception("Error updating collection time for retrieval");
            }
        }
        public Requisition updateRequisition(Requisition req)
        {
            dbcontext.Requisitions.Update(req);
            dbcontext.SaveChanges();
            return req;
        }

        public Requisition DeptHeadApprovRejRequisition(Requisition req)
        {
            try
            {
                var original = dbcontext.Requisitions.Find(req.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                original.Remarks = req.Remarks;
                original.Status = req.Status;
                dbcontext.SaveChanges();
                return original;
            }
            catch
            {
                throw new Exception("Error approving or rejecting requisition");
            }
        }

        public bool DeptEmpUpdateReceivedOnRequisition(int empid, int requisitionId, long date, string status)
        {
            try
            {
                var original = dbcontext.Requisitions.Find(requisitionId);
                if (original != null)
                {
                    original.Status = status;
                    original.ReceivedByRepId = empid;
                    original.ReceivedDate = date;
                }
            }
            catch
            {
                throw new Exception("Error updating receival on requisition ");
            }
            dbcontext.SaveChanges();
            return true;
        }

        public bool ClerkCompleteRequisition(int clerkid, int requisitionId, long date, string status)
        {
            try
            {
                var original = dbcontext.Requisitions.Find(requisitionId);
                if (original != null)
                {
                    original.Status = status;
                    original.AckByClerkId = clerkid;
                    original.AckDate = date;
                }
            }
            catch
            {
                throw new Exception("Error updating clerk acknowledgement on requisition ");
            }
            dbcontext.SaveChanges();
            return true;

        }

        public bool DeptRepUpdateRequisitionCollectionPoint(string deptid, int collectionpointId)
        {
            try
            {
                List<Requisition> deptreqlist = dbcontext.Requisitions.Where(m => m.DepartmentId == deptid).ToList();
                IEnumerable<Requisition> reqlist = from r in deptreqlist
                                                   where r.Status == Status.RequsitionStatus.created || r.Status == Status.RequsitionStatus.pendapprov
                                                   select r;
                foreach (Requisition rq in reqlist)
                {
                    rq.CollectionPointId = collectionpointId;
                }
            }
            catch
            {
                throw new Exception("Error updating collection point for existing pending or creating requisition.");
            }
            dbcontext.SaveChanges();
            return true;
        }
    }
    
}

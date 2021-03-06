using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.Common;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class RequisitionRepo
    {
        private SSISContext dbcontext;
        public RequisitionRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Requisition FindReqFormByReqID(int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m => m.RequisitionDetails).ThenInclude(m => m.Product)
                .Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.CollectionPoint)
                .Include(m => m.ApprovedBy)
                .Include(m => m.ReceivedByRep).Where(m => m.Id == reqId).FirstOrDefault();
            return req;
        }

        public List<Requisition> FindAllReqForm() 
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).Include(m => m.CollectionPoint).ToList();
            return lr;
        }

        public List<Requisition> FindReqFormByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.CollectionPoint)
                .Include(m => m.ReceivedByRep)
                .Where(m => m.DepartmentId == deptID).ToList();
            return lr;
        }

        public List<Requisition> DeptHeadfindreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions
                .Include(m => m.ReqByEmp)
                .Where(m => m.DepartmentId == deptID && m.Status != Status.RequsitionStatus.created)
                .ToList();
            return lr;
        }

        public List<Requisition> FindAllDisbursement()
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.ReceivedByRep)
                .Include(m => m.CollectionPoint)
                .Include(m => m.RequisitionDetails)
                .Where(m => m.Status == Status.RequsitionStatus.confirmed || m.Status == Status.RequsitionStatus.received || m.Status == Status.RequsitionStatus.completed).ToList();
            return lr;
        }
        public List<Requisition> FindDisbursementByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.ReceivedByRep)
                .Include(m => m.CollectionPoint)
                .Include(m => m.RequisitionDetails)
                .Where(m => m.DepartmentId == deptID)
                .Where(m => m.Status == Status.RequsitionStatus.confirmed || m.Status == Status.RequsitionStatus.received || m.Status == Status.RequsitionStatus.completed).ToList();
            return lr;
        }
        public List<Requisition> FindDisbursementByDeptIDandDate(string deptId, long date)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department)
                .Include(m => m.ReqByEmp)
                .Include(m => m.ReceivedByRep)
                .Include(m => m.CollectionPoint)
                .Include(m=>m.AckByClerk)
                .Include(m => m.RequisitionDetails).ThenInclude(m=>m.Product)
                .Where(m => m.DepartmentId == deptId)
                .Where(m=>m.CollectionDate == date)
                .Where(m => m.Status == Status.RequsitionStatus.confirmed || m.Status == Status.RequsitionStatus.received || m.Status == Status.RequsitionStatus.completed).ToList();
            return lr;
        }

        public List<Requisition> FindRequsitionByCollectionDateAndStatus(long date, int clerkid, string reqStatus)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.RequisitionDetails)
                .ThenInclude(m => m.Product)
                .Include(m => m.CollectionPoint)
                .Include(m => m.Department)
                .Include(m => m.ReceivedByRep)
                .Where(m => m.CollectionDate == date && m.ProcessedByClerkId == clerkid && m.Status == reqStatus).ToList();
            return lr;
        }

        public Requisition FindReqByReqId(int reqId)
        {
            Requisition req = dbcontext.Requisitions.Include(m => m.CollectionPoint).Include(m => m.RequisitionDetails).ThenInclude(m => m.Product).Include(m => m.ReceivedByRep)
                .Include(m => m.ReqByEmp).Include(m => m.Department).Include(m => m.CollectionPoint).FirstOrDefault(m => m.Id == reqId);
            return req;
        }

        public Requisition SaveNewRequisition(Requisition req)
        {
            dbcontext.Requisitions.Add(req);
            dbcontext.SaveChanges();
            return req;
        }

        public Requisition UpdateRequisitionCollectionTime(Requisition r1)
        {
            try
            {
                var original = dbcontext.Requisitions.Include(m => m.Department).Include(m => m.CollectionPoint).Include(m => m.ReceivedByRep).FirstOrDefault(m => m.Id == r1.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                original.CollectionDate = r1.CollectionDate;
                original.Status = r1.Status;
                original.ProcessedByClerkId = r1.ProcessedByClerkId;
                dbcontext.SaveChanges();
                return original;
            }
            catch
            {
                throw new Exception("Error updating collection time for retrieval");
            }
        }
        public Requisition UpdateRequisition(Requisition req)
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
                    throw new Exception("Error approving or rejecting requisition");
                }
                if (original.ReqByEmpId == req.ApprovedById)
                {
                    throw new Exception("Sorry, you are not allowed to approve or reject your own requisition");
                }
                original.Remarks = req.Remarks;
                original.Status = req.Status;
                original.ApprovedById = req.ApprovedById;
                original.ApprovalDate = req.ApprovalDate;
                dbcontext.SaveChanges();

                Requisition reqnew = dbcontext.Requisitions.Include(m => m.RequisitionDetails).ThenInclude(m => m.Product)
                        .Include(m => m.Department)
                        .Include(m => m.ReqByEmp)
                        .Include(m => m.CollectionPoint)
                        .Include(m => m.ApprovedBy)
                        .Include(m => m.ReceivedByRep).Where(m => m.Id == original.Id).FirstOrDefault();
                return reqnew;
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
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
        public bool DeleteRequisitionById(int reqId)
        {
            Requisition original = dbcontext.Requisitions.Where(m => m.Id == reqId).FirstOrDefault();
            if(original != null)
            {
                dbcontext.Requisitions.Remove(original);
            }
            dbcontext.SaveChanges();
            return true;
        }
    }

}

using Microsoft.AspNetCore.Http;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class DepartmentEmpServiceImpl : IDepartmentEmpService
    {
        private RequisitionRepo rrepo;
        private RequisitionDetailRepo rdrepo;
        private ProductRepo prepo;
        private EmployeeRepo erepo;
        private DepartmentRepo drepo;
        private CollectionPointRepo cprepo;

        public DepartmentEmpServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, ProductRepo prepo, EmployeeRepo erepo, DepartmentRepo drepo, CollectionPointRepo cprepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.prepo = prepo;
            this.erepo = erepo;
            this.drepo = drepo;
            this.cprepo = cprepo;
        }
        public List<Requisition> getdeptreqlist(string deptId)
        {
            return rrepo.findreqformByDeptID(deptId);
        }
        public Requisition getrfdetail(int reqId)
        {
            Requisition req = rrepo.findreqByReqId(reqId);
            return req;
        }
        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }
        public bool updatereqform(List<RequisitionDetail> rdlist)
        {

            foreach(RequisitionDetail r in rdlist) //Delete all old entries based on requisitionId
            {
                rdrepo.deleteRequisitionDetailByRequisitionId(r);
            }

            foreach (RequisitionDetail rd in rdlist) //Create new latest entries based on requisitionId 
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.addreqformitem(rd);
                }
            }
            //int requisitionId = (int)rdlist[0].RequisitionId; //logic changed by tk. line not required anymore
            //Requisition req = rrepo.findreqByReqId(requisitionId); //logic changed by tk. line not required anymore
            return true;
        }

        public Requisition createrequisition(int empid,string deptid)
        {
            Employee emp = erepo.findempById(empid);
            if(emp.Role == "dh")
            {
                throw new Exception("Sorry, department head cannot create own requisition");
            }
            
            //create empty requisition with date,employee ID and departmentid
            Requisition newform = new Requisition();

            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long date = dt.ToUnixTimeMilliseconds();

            newform.ReqByEmpId = empid;
            //newform.CreatedDate= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); //From tk: changed date format to UTC 00:00 for date
            newform.CreatedDate = date;
            newform.DepartmentId = deptid;
            newform.Status = Status.RequsitionStatus.created;

            return rrepo.saveNewRequisition(newform);
        }
        public bool submitrf(List<RequisitionDetail> rdlist)
        {
            foreach (RequisitionDetail r in rdlist) //Delete all old entries based on requisitionId
            {
                rdrepo.deleteRequisitionDetailByRequisitionId(r);
            }

            foreach (RequisitionDetail rd in rdlist) //Create new latest entries based on requisitionId 
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.addreqformitem(rd);
                }
            }
            
            // Updating Requisition to "Pending Approval" status
            int requisitionId = (int)rdlist[0].RequisitionId;
            Requisition req = rrepo.findreqByReqId(requisitionId);
            req.Status = Status.RequsitionStatus.pendapprov;

            //Finding supervisor Email address to send auto email
            Requisition updatedreq = rrepo.updateRequisition(req);
            int deptemp = updatedreq.ReqByEmpId;
            Employee depthead = erepo.findSupervisorByEmpId(deptemp);

            //send email to dept manager(PENDING)
            // if (supervisor !=null){}
            return true;                  
        }

        public Department GetDepartment(string deptId)
        {
            Department dept = drepo.findDepartmentById(deptId);
            return dept;
        }

        public List<CollectionPoint> GetAllCollectionPoint()
        {
            List<CollectionPoint> clist = cprepo.GetAllCollectionPoint();
            return clist;
        }

        public bool UpdateCollectionPoint(string deptid, CollectionPoint cp)
        {
            int collectionpointId = cp.Id;
            drepo.UpdateCollectionPoint(deptid, collectionpointId);

            //For requisition with status "created" and "pending approval", their collection point need to be updated with new collection point
            try
            {
                rrepo.DeptRepUpdateRequisitionCollectionPoint(deptid, collectionpointId);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return true;
        }

        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate)
        {
            List<RequisitionDetail> rdl = rdrepo.GetDisbursementByDate(deptid, longdate);
            return rdl;
        }

        public bool AckItemReceived(int empid, List<RequisitionDetail> rdlist)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
                long date = dt.ToUnixTimeMilliseconds();
                foreach (RequisitionDetail r in rdlist)
                {
                    rdrepo.EmpAckItemReceived(r);
                    rrepo.DeptEmpUpdateReceivedOnRequisition(empid, (int)r.RequisitionId, date, Status.RequsitionStatus.received);
                }
                return true;
            }
            catch(Exception m)
            {
                throw m;
            }
        }
    }
}

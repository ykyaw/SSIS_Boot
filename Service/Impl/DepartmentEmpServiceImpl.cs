using SSIS_BOOT.Common;
using SSIS_BOOT.Email;
using SSIS_BOOT.Email.EmailTemplates;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
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
        protected IMailer mailservice;

        public DepartmentEmpServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, ProductRepo prepo, EmployeeRepo erepo, 
            DepartmentRepo drepo, CollectionPointRepo cprepo, IMailer mailservice)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.prepo = prepo;
            this.erepo = erepo;
            this.drepo = drepo;
            this.cprepo = cprepo;
            this.mailservice = mailservice;
        }
        public List<Requisition> getdeptreqlist(string deptId)
        {
            return rrepo.findreqformByDeptID(deptId);
        }

        public List<Requisition> GetAllDeptDisbursementList(string deptId)
        {
            List<Requisition> lr = rrepo.finddisbursementByDeptID(deptId);
            return lr;
        }

        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate)
        {
            //RequisitionDetail has no deptid and date. Need to retrieve by requisition
            List<Requisition> reqlist = rrepo.finddisbursementByDeptIDandDate(deptid, longdate);
            List<RequisitionDetail> rdlist = new List<RequisitionDetail>();
            foreach(Requisition r in reqlist)
            {
                rdlist.AddRange(r.RequisitionDetails);
            }
            return rdlist;
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
            Department dept = drepo.findDepartmentById(deptid);
            newform.CollectionPointId = dept.CollectionPointId;

            return rrepo.saveNewRequisition(newform);
        }

        public Requisition createrequisitionfromhistory(int empid, string deptid, List<RequisitionDetail> rdlist)
        {
            Employee emp = erepo.findempById(empid);
            if (emp.Role == "dh")
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
            Department dept = drepo.findDepartmentById(deptid);
            newform.CollectionPointId = dept.CollectionPointId;

            Requisition r = rrepo.saveNewRequisition(newform);
            foreach(RequisitionDetail rd in rdlist)
            {
                rd.RequisitionId = r.Id;
                rdrepo.addreqformitem(rd);
            }
            return rrepo.findreqByReqId(r.Id);
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
            
            //add the current date to be the submitted date.
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long submitdate = dt.ToUnixTimeMilliseconds();
            req.SubmittedDate = submitdate;

            //Finding deptemp 
            Requisition updatedreq = rrepo.updateRequisition(req);
            int deptempid = updatedreq.ReqByEmpId;
            Employee deptemp = erepo.findempById(deptempid);

            //send to manager
            Employee depthead = erepo.findSupervisorByEmpId(deptempid);

            EmailModel email = new EmailModel();
            Task.Run(async () =>
            {
                EmailTemplates.SubmitreqformTemplate srf = new EmailTemplates.SubmitreqformTemplate(updatedreq, depthead, deptemp);
                email.emailTo = depthead.Email;
                email.emailSubject = srf.subject;
                email.emailBody = srf.body;
                await mailservice.SendEmailAsync(email);
            });

            //check if there is delegate
            Employee delegateemp = erepo.getcurrentdelegate(submitdate, deptemp.DepartmentId);
            if (delegateemp != null)
            {

                //send email to delegate 
                EmailModel email2 = new EmailModel();
                Task.Run(async () =>
                {
                    EmailTemplates.SubmitreqformTemplate srf = new EmailTemplates.SubmitreqformTemplate(updatedreq, delegateemp, deptemp);
                    email.emailTo = delegateemp.Email;
                    email.emailSubject = srf.subject;
                    email.emailBody = srf.body;
                    await mailservice.SendEmailAsync(email);
                });
            }
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

        public Employee FindEmployeeById(int RepId)
        {
            Employee drep = erepo.findempById(RepId);
            return drep;
        }

        public bool DeleteCreatedRequisition(int reqId)
        {
            Requisition req = rrepo.findreqByReqId(reqId);
            List<RequisitionDetail> reqd = rdrepo.GetRequisitionDetailByRequisitionId(reqId);
            foreach (RequisitionDetail r in reqd)
            {
                rdrepo.deleteRequisitionDetailByRequisitionId(r);
            }
            rrepo.DeleteRequisitionById(reqId);
            return true;
        }
    }
}

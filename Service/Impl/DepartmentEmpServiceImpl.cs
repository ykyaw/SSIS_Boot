using SSIS_BOOT.Common;
using SSIS_BOOT.Email;
using SSIS_BOOT.Email.EmailTemplates;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
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
        public List<Requisition> GetDeptReqList(string deptId)
        {
            return rrepo.FindReqFormByDeptID(deptId);
        }
        public List<Requisition> GetAllDeptDisbursementList(string deptId)
        {
            List<Requisition> lr = rrepo.FindDisbursementByDeptID(deptId);
            return lr;
        }
        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate)
        {
            List<Requisition> reqlist = rrepo.FindDisbursementByDeptIDandDate(deptid, longdate);
            List<RequisitionDetail> rdlist = new List<RequisitionDetail>();
            foreach (Requisition r in reqlist)
            {
                rdlist.AddRange(r.RequisitionDetails);
            }
            return rdlist;
        }
        public Requisition GetRfDetail(int reqId)
        {
            Requisition req = rrepo.FindReqByReqId(reqId);
            return req;
        }
        public List<Product> GetAllCat()
        {
            return prepo.FindAllCat();
        }
        public bool UpdateReqForm(List<RequisitionDetail> rdlist)
        {
            foreach (RequisitionDetail r in rdlist) //Delete all old entries based on requisitionId
            {
                rdrepo.DeleteRequisitionDetailByRequisitionId(r);
            }

            foreach (RequisitionDetail rd in rdlist) //Create new latest entries based on requisitionId 
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.AddReqFormItem(rd);
                }
            }
            return true;
        }

        public Requisition CreateRequisition(int empid, string deptid)
        {
            Employee emp = erepo.FindEmpById(empid);
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
            newform.CreatedDate = date;
            newform.DepartmentId = deptid;
            newform.Status = Status.RequsitionStatus.created;
            Department dept = drepo.FindDepartmentById(deptid);
            newform.CollectionPointId = dept.CollectionPointId;
            return rrepo.SaveNewRequisition(newform);
        }

        public Requisition CreateRequisitionFromHistory(int empid, string deptid, List<RequisitionDetail> rdlist)
        {
            Employee emp = erepo.FindEmpById(empid);
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
            newform.CreatedDate = date;
            newform.DepartmentId = deptid;
            newform.Status = Status.RequsitionStatus.created;
            Department dept = drepo.FindDepartmentById(deptid);
            newform.CollectionPointId = dept.CollectionPointId;
            Requisition r = rrepo.SaveNewRequisition(newform);
            foreach (RequisitionDetail rd in rdlist)
            {
                rd.RequisitionId = r.Id;
                rdrepo.AddReqFormItem(rd);
            }
            return rrepo.FindReqByReqId(r.Id);
        }
        public bool SubmiTrf(List<RequisitionDetail> rdlist)
        {
            foreach (RequisitionDetail r in rdlist) //Delete all old entries based on requisitionId
            {
                rdrepo.DeleteRequisitionDetailByRequisitionId(r);
            }
            foreach (RequisitionDetail rd in rdlist) //Create new latest entries based on requisitionId 
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.AddReqFormItem(rd);
                }
            }
            // Updating Requisition to "Pending Approval" status
            int requisitionId = (int)rdlist[0].RequisitionId;
            Requisition req = rrepo.FindReqByReqId(requisitionId);
            req.Status = Status.RequsitionStatus.pendapprov;

            //add the current date to be the submitted date.
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long submitdate = dt.ToUnixTimeMilliseconds();
            req.SubmittedDate = submitdate;

            //Finding deptemp 
            Requisition updatedreq = rrepo.UpdateRequisition(req);
            int deptempid = updatedreq.ReqByEmpId;
            Employee deptemp = erepo.FindEmpById(deptempid);

            //send to manager
            Employee depthead = erepo.FindSupervisorByEmpId(deptempid);

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
            Employee delegateemp = erepo.GetCurrentDelegate(submitdate, deptemp.DepartmentId);
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
            Department dept = drepo.FindDepartmentById(deptId);
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
            catch (Exception e)
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
            catch (Exception m)
            {
                throw m;
            }
        }
        public Employee FindEmployeeById(int RepId)
        {
            Employee drep = erepo.FindEmpById(RepId);
            return drep;
        }
        public bool DeleteCreatedRequisition(int reqId)
        {
            Requisition req = rrepo.FindReqByReqId(reqId);
            List<RequisitionDetail> reqd = rdrepo.GetRequisitionDetailByRequisitionId(reqId);
            foreach (RequisitionDetail r in reqd)
            {
                rdrepo.DeleteRequisitionDetailByRequisitionId(r);
            }
            rrepo.DeleteRequisitionById(reqId);
            return true;
        }
        public bool EmptyCreatedRequisition(int reqId)
        {
            Requisition req = rrepo.FindReqByReqId(reqId);
            List<RequisitionDetail> reqd = rdrepo.GetRequisitionDetailByRequisitionId(reqId);
            foreach (RequisitionDetail r in reqd)
            {
                rdrepo.DeleteRequisitionDetailByRequisitionId(r);
            }
            return true;
        }
    }
}

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
    public class DepartmentHeadServiceImpl : IDepartmentHeadService
    {
        private RequisitionRepo rrepo;
        private RequisitionDetailRepo rdrepo;
        private EmployeeRepo erepo;
        private DepartmentRepo drepo;
        protected IMailer mailservice;
        private CollectionPointRepo crepo;
        public DepartmentHeadServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, EmployeeRepo erepo, DepartmentRepo drepo, IMailer mailservice, CollectionPointRepo crepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.erepo = erepo;
            this.drepo = drepo;
            this.mailservice = mailservice;
            this.crepo = crepo;
        }
        public bool ApprovRejRequisition(Requisition req)
        {
            try
            {

                Requisition updatedreq = rrepo.DeptHeadApprovRejRequisition(req);
                Employee deptemp = updatedreq.ReqByEmp;
                Employee approvedby = updatedreq.ApprovedBy;
                EmailModel email = new EmailModel();

                Task.Run(async () =>
                {
                    EmailTemplates.ProcessedreqTemplate prt = new EmailTemplates.ProcessedreqTemplate(updatedreq, deptemp, approvedby);
                    email.emailTo = deptemp.Email;
                    email.emailSubject = prt.subject;
                    email.emailBody = prt.body;
                    await mailservice.SendEmailAsync(email);
                });
                return true;

            }
            catch (Exception m)
            {
                throw m;
            }
        }
        public List<Employee> GetAllDeptEmployee(string deptid)
        {
            List<Employee> emplist = erepo.FindEmpByDept(deptid);
            return emplist;
        }
        public List<Requisition> DeptHeadGetdeptReqlist(string deptId)
        {
            List<Requisition> lr = rrepo.DeptHeadfindreqformByDeptID(deptId);
            return lr;
        }
        public List<Requisition> GetDeptDisbursementList(string deptid)
        {
            List<Requisition> lr = rrepo.FindDisbursementByDeptID(deptid);
            return lr;
        }
        public Requisition GetRfDetail(int reqId)
        {
            Requisition req = rrepo.FindReqByReqId(reqId);
            return req;
        }
        public bool AssignDelegate(Employee emp, string deptid)
        {
            List<Employee> emplist = erepo.FindEmpByDept(deptid);
            foreach (Employee e in emplist)
            {

                if (emp.DelegateFromDate >= e.DelegateFromDate && emp.DelegateFromDate <= e.DelegateToDate)
                {
                    if (emp.Id != e.Id)
                    {
                        throw new Exception("Conflict of delegate dates with " + e.Name + ". Please try again");
                    }
                }
                if (emp.DelegateToDate >= e.DelegateFromDate && emp.DelegateToDate <= e.DelegateToDate)
                {
                    if (emp.Id != e.Id)
                    {
                        throw new Exception("Conflict of delegate dates with " + e.Name + ". Please try again");
                    }
                }
            }
            try
            {
                Employee delegateemp = erepo.AssignDelegateDate(emp);
                Employee depthead = erepo.FindSupervisorByEmpId(delegateemp.Id);
                EmailModel email = new EmailModel();

                Task.Run(async () =>
                {
                    EmailTemplates.AssignDelTemplate adt = new EmailTemplates.AssignDelTemplate(delegateemp, depthead);
                    email.emailTo = delegateemp.Email;
                    email.emailSubject = adt.subject;
                    email.emailBody = adt.body;
                    await mailservice.SendEmailwithccallAsync(email, emplist);
                });
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool AssignDeptRep(int empid, string deptid)
        {
            try
            {
                drepo.AssignDeptRep(empid, deptid);
                Employee deptrep = erepo.FindEmpById(empid);
                Employee depthead = erepo.FindSupervisorByEmpId(deptrep.Id);
                //find collectionpoint
                Department dp = drepo.FindDeptbyRepID(deptrep.Id);
                CollectionPoint deptCP = crepo.GetDeptCollectionPoint(dp);
                EmailModel email = new EmailModel();
                Task.Run(async () =>
                {
                    EmailTemplates.AssignDeptRepTemplate adt = new EmailTemplates.AssignDeptRepTemplate(deptrep, depthead, deptCP);
                    email.emailTo = deptrep.Email;
                    email.emailSubject = adt.subject;
                    email.emailBody = adt.body;
                    await mailservice.SendEmailAsync(email);
                });
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee GetCurrentDelegate(string deptid)
        {
            long currentdate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Employee del = erepo.GetCurrentDelegate(currentdate, deptid);
            return del;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> dlist = drepo.FindAllDepartment();
            return dlist;
        }

        public Department FindDepartmentById(string deptid)
        {
            return drepo.FindDepartmentById(deptid);
        }
    }
}

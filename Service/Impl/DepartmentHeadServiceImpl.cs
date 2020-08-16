using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class DepartmentHeadServiceImpl:IDepartmentHeadService
    {
        private RequisitionRepo rrepo;
        private RequisitionDetailRepo rdrepo;
        private EmployeeRepo erepo;
        private DepartmentRepo drepo;

        public DepartmentHeadServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, EmployeeRepo erepo, DepartmentRepo drepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.erepo = erepo;
            this.drepo = drepo;
        }

        public bool ApprovRejRequisition(Requisition req)
        {
            try
            {
                rrepo.DeptHeadApprovRejRequisition(req);
                return true;
            }
            catch (Exception m)
            {
                throw m;
            }         
        }

        public List<Employee> GetAllDeptEmployee(string deptid)
        {
            List<Employee> emplist = erepo.findEmpByDept(deptid);
            return emplist;
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

        public bool AssignDelegate(Employee emp, string deptid)
        {
            List<Employee> emplist = erepo.findEmpByDept(deptid);
            foreach(Employee e in emplist)
            {
                if(emp.DelegateFromDate >= e.DelegateFromDate && emp.DelegateToDate <= e.DelegateToDate)
                {
                    throw new Exception("Conflict of delegate dates with " + e.Name + ". Please try again");
                }
            }
            try
            {
                erepo.AssignDelegateDate(emp);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }       
        }

        public bool AssignDeptRep(int empid, string deptid)
        {
            try
            {
                drepo.AssignDeptRep(empid, deptid);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

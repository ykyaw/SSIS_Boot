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

        public DepartmentHeadServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, EmployeeRepo erepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.erepo = erepo;
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
    }
}

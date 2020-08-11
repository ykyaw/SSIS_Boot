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

        public DepartmentEmpServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
        }
        public List<Requisition> getdeptreqlist(string deptId)
        {
            return rrepo.findreqformByDeptID(deptId);
        }
        public List<RequisitionDetail> getrfdetail(int reqId)
        {
            return rdrepo.getrequisitiondetail(reqId);
        }

    }
}

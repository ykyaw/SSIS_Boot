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
        public RequisitionRepo rrepo;
        public RequisitionDetailRepo rdrepo;

        public DepartmentHeadServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
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

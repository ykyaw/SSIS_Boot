using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IDepartmentEmpService
    {
        public List<Requisition> getdeptreqlist(string deptId);

        public Requisition getrfdetail(int reqId);
        public List<Product> getallcat();

        public Requisition updatereqform(List<RequisitionDetail> rdlist);
    }
}

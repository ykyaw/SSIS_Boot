using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IDepartmentHeadService
    {
        public List<Requisition> getdeptreqlist(string deptId);

        public Requisition getrfdetail(int reqId);

        public List<Employee> GetAllDeptEmployee(string deptid);

        public bool ApprovRejRequisition(Requisition req);
    }
}

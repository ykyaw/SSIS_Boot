using SSIS_BOOT.Models;
using System.Collections.Generic;


namespace SSIS_BOOT.Service.Interfaces
{
    public interface IDepartmentHeadService
    {
        public List<Requisition> DeptHeadGetdeptReqlist(string deptId);
        public List<Requisition> GetDeptDisbursementList(string deptid);
        public Requisition GetRfDetail(int reqId);
        public List<Employee> GetAllDeptEmployee(string deptid);
        public bool ApprovRejRequisition(Requisition req);
        public bool AssignDelegate(Employee emp, string deptid);
        public bool AssignDeptRep(int empid, string deptid);
        public Employee GetCurrentDelegate(string deptid);
        public List<Department> GetAllDepartment();
        public Department FindDepartmentById(string deptid);
    }
}

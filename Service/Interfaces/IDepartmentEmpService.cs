using SSIS_BOOT.Models;
using System.Collections.Generic;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IDepartmentEmpService
    {
        public List<Requisition> GetDeptReqList(string deptId);
        public List<Requisition> GetAllDeptDisbursementList(string deptId);
        public Requisition GetRfDetail(int reqId);
        public List<Product> GetAllCat();
        public Requisition CreateRequisition(int empid,string deptid);
        public Requisition CreateRequisitionFromHistory(int empid, string deptid, List<RequisitionDetail>rdlist);
        public bool UpdateReqForm(List<RequisitionDetail> rdlist);
        public bool SubmiTrf(List<RequisitionDetail> rdlist);
        public Department GetDepartment(string deptId);
        public List<CollectionPoint> GetAllCollectionPoint();
        public bool UpdateCollectionPoint(string deptid, CollectionPoint cp);
        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate);
        public bool AckItemReceived(int empid, List<RequisitionDetail>rdlist);
        public Employee FindEmployeeById(int RepId);
        public bool DeleteCreatedRequisition(int reqId);
        public bool EmptyCreatedRequisition(int reqId);
    }
}

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
        public List<Requisition> getdeptdisbursementlist(string deptId);

        public Requisition getrfdetail(int reqId);
        public List<Product> getallcat();
        public Requisition createrequisition(int empid,string deptid);

        public bool updatereqform(List<RequisitionDetail> rdlist);

        public bool submitrf(List<RequisitionDetail> rdlist);


        public Department GetDepartment(string deptId);
        public List<CollectionPoint> GetAllCollectionPoint();
        public bool UpdateCollectionPoint(string deptid, CollectionPoint cp);

        public List<RequisitionDetail> GetDisbursementByDate(string deptid, long longdate);

        public bool AckItemReceived(int empid, List<RequisitionDetail>rdlist);

        public Employee FindEmployeeById(int RepId);
    }
}

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
        private ProductRepo prepo;

        public DepartmentEmpServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, ProductRepo prepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.prepo = prepo;
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
        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }

        public Requisition updatereqform(List<RequisitionDetail> rdlist)
        {
            //    foreach (RequisitionDetail rd in rdlist)
            //    {
            //        Requisition
            //        rrepo.updatereqformitem(rd);
            //    }
            //    // return the requistion object

            //    foreach (String id in productid)
            //    {
            //        PurchaseRequestDetail prd1 = new PurchaseRequestDetail();
            //        prd1.ProductId = id;
            //        prd1.Status = Status.PurchaseRequestStatus.created;
            //        prd1.PurchaseRequestId = currentpurchaserequestid;
            //        //prd1.CreatedByClerkId = (int)2;
            //        prd1.CreatedByClerkId = clerkId;
            //        purreqrepo.addnewpurchaserequestdetail(prd1);
            //    }
            //    List<PurchaseRequestDetail> prlist = purreqrepo.getcurrentpurchaserequest(currentpurchaserequestid);
            throw new NotImplementedException();
        }

    }
}

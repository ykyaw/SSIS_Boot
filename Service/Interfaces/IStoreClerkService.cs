using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreClerkService
    {
        public List<Product> getallcat();
        public List<PurchaseRequestDetail> getpurchasereq();
        public List<PurchaseRequestDetail> getprdetails(long prid);
        public List<PurchaseOrder> getpurchaseorders();

        public List<PurchaseOrderDetail> getpoddetails(int poId);

        public List<Requisition> getallreqform();

        public List<Requisition> getReqformByDeptId(string deptID);

        public Requisition getReqByReqId(int reqid);

        public List<Transaction> retrievestockcard(string productId);

        public Retrieval genretrievalform(long date, int clerkid);
        public List<TenderQuotation> gettop3suppliers(string productId);

        public List<RequisitionDetail> retrievedisbursementlist(string deptId, long collectiondate);

        public bool savetransaction(Transaction t1);

        public List<PurchaseRequestDetail> addpurchaserequest(List<String> productId,int clerkid);
        public bool updatepurchaserequestitem(List<PurchaseRequestDetail> prdlist);

        public bool updateretrieval(Retrieval r1);
        public List<Requisition> getallreqformbydate(long date);

        public bool updatepurchaseorderdetailitem(PurchaseOrderDetail pod);

        public bool generatequotefrompr(List<PurchaseRequestDetail> prd);

        public AdjustmentVoucher createadjustmentvoucher();
    }
}

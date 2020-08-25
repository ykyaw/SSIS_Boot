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
        List<Transaction> getlatesttransaction(List<Product> pdt);

        public List<PurchaseRequestDetail> getpurchasereq();
        public List<PurchaseRequestDetail> getprdetails(long prid);
        public List<PurchaseOrder> getpurchaseorders();

        public List<PurchaseOrderDetail> getpoddetails(int poId);

        public List<Requisition> getallreqform();

        public List<Requisition> getReqformByDeptId(string deptID);

        public Requisition getReqByReqId(int reqid);

        public bool updaterequisitioncollectiontime(Requisition r1);

        public List<Transaction> retrievestockcard(string productId);

        public Retrieval genretrievalform(long date, int clerkid, List<Requisition> listreq);
        public List<TenderQuotation> gettop3suppliers(string productId);

        public List<RequisitionDetail> retrievedisbursementlist(string deptId, long collectiondate);

        public bool savetransaction(Transaction t1);

        public List<PurchaseRequestDetail> addpurchaserequest(List<String> productId, int clerkid);
        public bool updatepurchaserequestitem(List<PurchaseRequestDetail> prdlist);

        public bool updateretrieval(Retrieval r1);
        public List<Requisition> getallreqformbydateandstatus(long date, int clerkid, string reqStatus);

        public bool updatepurchaseorderdetailitem(List<PurchaseOrderDetail> pod);

        public bool generatequotefrompr(List<PurchaseRequestDetail> prd,int clerkid);


        public AdjustmentVoucher createadjustmentvoucher(int clerkid);

        public List<AdjustmentVoucher> getAllAdjustmentVoucher();

        public List<Department> getalldepartment();

        public List<AdjustmentVoucherDetail> getAdvDetailsbyAdvId(string advId);

        public bool AckCompletedRequisition(List<RequisitionDetail> rdl, int clerkId);

        public bool updateAdjustmentVoucherDeatails(List<AdjustmentVoucherDetail> voucherDetails);

        public bool ClerkSubmitAdjustmentVoucher(string adjustmentVoucherId);

        public AdjustmentVoucher findAdjustmentVoucherById(string advId);
        public List<AdjustmentVoucher> findAdjustmentVoucherByClerkId(int clerkid);

        public TenderQuotation getFirstTenderbyProdutId(string ProductId);

        //public bool SaveEmptyAdjustmentDetails(string AdjustmentVoucherId);

        public List<Retrieval> GetRetrievalFormCommentsForAdjustmentVoucher();

        public List<Requisition> GetAllDisbursement();

        public List<Retrieval> GetAllRetrievals();
    }
}

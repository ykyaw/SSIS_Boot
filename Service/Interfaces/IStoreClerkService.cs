using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreClerkService
    {
        public List<Product> GetAllCat();
        List<Transaction> GetLatestTransaction(List<Product> pdt);
        public List<PurchaseRequestDetail> GetPurchaseReq();
        public List<PurchaseRequestDetail> GetPrDetails(long prid);
        public List<PurchaseOrder> GetPurchaseOrders();
        public List<PurchaseOrderDetail> GetPodDetails(int poId);
        public List<Requisition> GetAllReqForm();
        public List<Requisition> GetReqFormByDeptId(string deptID);
        public Requisition GetReqByReqId(int reqid);
        public bool UpdateRequisitionCollectionTime(Requisition r1);
        public List<Transaction> RetrieveStockcard(string productId);
        public Retrieval GenRetrievalForm(long date, int clerkid, List<Requisition> listreq);
        public List<TenderQuotation> GetTop3Suppliers(string productId);
        public List<RequisitionDetail> RetrieveDisbursementList(string deptId, long collectiondate);
        public bool SaveTransaction(Transaction t1);
        public List<PurchaseRequestDetail> AddPurchaseRequest(List<String> productId, int clerkid);
        public bool UpdatePurchaseRequestItem(List<PurchaseRequestDetail> prdlist);
        public bool UpdateRetrieval(Retrieval r1);
        public List<Requisition> GetAllReqFormByDateAndStatus(long date, int clerkid, string reqStatus);
        public bool UpdatePurchaseOrderDetailItem(List<PurchaseOrderDetail> pod);
        public bool GenerateQuoteFromPr(List<PurchaseRequestDetail> prd, int clerkid);
        public AdjustmentVoucher CreateAdjustmentVoucher(int clerkid);
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher();
        public List<Department> GetAllDepartment();
        public List<AdjustmentVoucherDetail> GetAdvDetailsByAdvId(string advId);
        public bool AckCompletedRequisition(List<RequisitionDetail> rdl, int clerkId);
        public bool UpdateAdjustmentVoucherDeatails(List<AdjustmentVoucherDetail> voucherDetails);
        public bool ClerkSubmitAdjustmentVoucher(string adjustmentVoucherId);
        public AdjustmentVoucher FindAdjustmentVoucherById(string advId);
        public List<AdjustmentVoucher> FindAdjustmentVoucherByClerkId(int clerkid);
        public TenderQuotation GetFirstTenderbyProdutId(string ProductId);
        public List<Retrieval> GetRetrievalFormCommentsForAdjustmentVoucher();
        public List<Requisition> GetAllDisbursement();
        public List<Retrieval> GetAllRetrievals();
        public Retrieval GetRetrievalById(int rId);
        public bool DeleteCreatedPurchaseRequest(long preqId);
        public bool DeleteCreatedAdjustmentVoucher(string avId);
        public bool EmptyCreatedAdjustmentVoucher(string avId);

    }
}

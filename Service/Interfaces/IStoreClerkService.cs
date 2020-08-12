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
        public List<PurchaseOrder> getpurchaseorders();

        public List<PurchaseOrderDetail> getpoddetails(int poId);

        public List<Requisition> getallreqform();

        public List<Requisition> getReqformByDeptId(string deptID);

        public List<Transaction> retrievestockcard(string productId);

        public Retrieval genretrievalform(long date, int clerkid);
        public List<TenderQuotation> gettop3suppliers(string productId);

        public List<RequisitionDetail> retrievedisbursementlist(string deptId, long collectiondate);

        public bool savetransaction(Transaction t1);

        public bool addpurchaserequest(PurchaseRequestDetail prd1);
        public List<PurchaseRequestDetail> getcurrentpurchaserequest(int purchaserequestId);
        public bool updatepurchaserequestitem(PurchaseRequestDetail prd);
    }
}

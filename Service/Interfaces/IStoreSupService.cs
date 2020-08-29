using SSIS_BOOT.Models;
using System.Collections.Generic;



namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreSupService
    {

        public AdjustmentVoucher GetAdjVouchById(string id);
        public bool ApprovRejAdjustmentVoucher(AdjustmentVoucher av, int approvalId);
        public List<PurchaseRequestDetail> GetPurchaseReq();
        public List<PurchaseRequestDetail> GetPrDetails(long prid);
        public bool UpdatePr(List<PurchaseRequestDetail> prdlist, int supid, long approveddate);
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher();

    }
}

using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IStoreSupService
    {

        public AdjustmentVoucher getAdjVouchById(string id);
        public bool ApprovRejAdjustmentVoucher(AdjustmentVoucher av, int approvalId);

        public List<PurchaseRequestDetail> getpurchasereq();
        public List<PurchaseRequestDetail> getprdetails(long prid);

        public bool updatepr(List<PurchaseRequestDetail> prdlist, int supid, long approveddate);


        public List<AdjustmentVoucher> getAllAdjustmentVoucher();

    }
}

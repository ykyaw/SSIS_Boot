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

        public List<AdjustmentVoucher> getAllAdjustmentVoucher();
    }
}

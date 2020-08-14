using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class AdjustmentVoucherDetailRepo
    {

        public SSISContext dbcontext;

        public AdjustmentVoucherDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }

        public List<AdjustmentVoucherDetail> findAdvDetailsbyAdvId(string advId)
        {

            List<AdjustmentVoucherDetail> advdetails = dbcontext.AdjustmentVoucherDetails
                .Include(m => m.AdjustmentVoucher)
                //.ThenInclude(m => m.InitiatedClerk)
                //.Include(m => m.AdjustmentVoucher)
                //.ThenInclude(m => m.ApprovedSup)
                //.Include(m => m.AdjustmentVoucher)
                //.ThenInclude(m => m.Status)
                //.Include(m => m.AdjustmentVoucher)
                //.ThenInclude(m => m.ApprovedMgr)
                //.Include(m => m.AdjustmentVoucher)
                //.ThenInclude(m => m.Reason)
                .Include(m => m.Product)
                .Where(m => m.AdjustmentVoucherId.Equals(advId)).ToList();
            return advdetails;
        }
    }
}

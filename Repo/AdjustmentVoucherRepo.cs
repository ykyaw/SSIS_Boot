using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class AdjustmentVoucherRepo
    {

        private SSISContext dbcontext;
        public AdjustmentVoucherRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<AdjustmentVoucher> findAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = dbcontext.AdjustmentVouchers.Include(m => m.InitiatedClerk)
                .Include(m => m.ApprovedSup)
                .Include(m=>m.ApprovedMgr)
                .Include(m=>m.AdjustmentVoucherDetails)
                .ToList();
            return advlist;
        }
    }
}

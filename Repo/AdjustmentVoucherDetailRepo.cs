using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class AdjustmentVoucherDetailRepo
    {

        public SSISContext dbcontext;
        public AdjustmentVoucherDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;

        }

        public List<AdjustmentVoucherDetail> FindAdvDetailsbyAdvId(string advId)
        {

            List<AdjustmentVoucherDetail> advdetails = dbcontext.AdjustmentVoucherDetails
                .Include(m => m.AdjustmentVoucher)
                .Include(m => m.Product)
                .Where(m => m.AdjustmentVoucherId.Equals(advId)).ToList();
            return advdetails;
        }

        public void DeleteAdvDetails(AdjustmentVoucherDetail avd)
        {
            AdjustmentVoucherDetail original = dbcontext.AdjustmentVoucherDetails.FirstOrDefault(m => m.Id == avd.Id);

            if (original != null)
            {
                dbcontext.AdjustmentVoucherDetails.Remove(original);
            }
            dbcontext.SaveChanges();
        }
        public void AddAdvDetail(AdjustmentVoucherDetail avd)
        {
            dbcontext.AdjustmentVoucherDetails.Add(avd);
            dbcontext.SaveChanges();
        }

    }
}

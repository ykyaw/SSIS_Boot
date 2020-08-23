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

        public bool hasDetails(string AdjustmentVoucherId)
        {
            AdjustmentVoucherDetail advdetail = dbcontext.AdjustmentVoucherDetails
                .Include(m => m.AdjustmentVoucher).Include(m => m.Product)
                .Where(m => m.AdjustmentVoucherId.Equals(AdjustmentVoucherId)).FirstOrDefault();
            if (advdetail != null)
                return true;
            else
                return false;
        }
        

        public void deleteAdvDetailsbyAdvId(string AdjustmentVoucherId) {

            List<AdjustmentVoucherDetail> advdetails = findAdvDetailsbyAdvId(AdjustmentVoucherId);
            foreach (AdjustmentVoucherDetail detail in advdetails)
            {
                dbcontext.AdjustmentVoucherDetails.Remove(detail);
                dbcontext.SaveChanges();
            }

        }

        public void deleteAdvDetails(AdjustmentVoucherDetail avd)
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

        public void updateAdjustmentVoucherDeatail(AdjustmentVoucherDetail avdetail)
        {
            dbcontext.AdjustmentVoucherDetails.Add(avdetail);
            dbcontext.SaveChanges();

        }




    }
}

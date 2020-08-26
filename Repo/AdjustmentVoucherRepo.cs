
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SSIS_BOOT.Common;

namespace SSIS_BOOT.Repo
{
    public class AdjustmentVoucherRepo
    {

        private SSISContext dbcontext;

        public AdjustmentVoucherRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public AdjustmentVoucher saveNewAdjustmentVoucher(AdjustmentVoucher av)
        {
            dbcontext.AdjustmentVouchers.Add(av);
            dbcontext.SaveChanges();
            return av;
        }
        public string createnewid()
        {
            // 029_06_2020
            AdjustmentVoucher lastcreatedvoucher = dbcontext.AdjustmentVouchers.OrderByDescending(x => x.InitiatedDate).Take(1).FirstOrDefault();
            string lastcreatedid = lastcreatedvoucher.Id;

            //string s = lastcreatedid.Substring(4,2);
            //string s1 = lastcreatedid.Substring(8,2);

            int lastnum = int.Parse(lastcreatedid.Substring(0, 3));
            int lastcreatedmonth = int.Parse(lastcreatedid.Substring(4, 2));
            int lastcreatedyear = int.Parse(lastcreatedid.Substring(7, 4));


            string num = "001";
            int initiatedatemonth = int.Parse(DateTime.Now.ToString("MM"));
            int initiatedateyear = int.Parse(DateTime.Now.ToString("yyyy"));

            if (lastcreatedmonth == initiatedatemonth && lastcreatedyear == initiatedateyear)
            {
                lastnum++;
                if (lastnum >= 10)
                {
                    string newid = string.Format("0{0}_{1}_{2}", lastnum, DateTime.Now.ToString("MM"), initiatedateyear);
                    return newid;
                }
                else
                {
                    string newid = string.Format("00{0}_{1}_{2}", lastnum, DateTime.Now.ToString("MM"), initiatedateyear);
                    return newid;
                }

            }
            else
            {
                string newid = string.Format("00{0}_0{1}_{2}", num, DateTime.Now.ToString("MM"), initiatedateyear);
                //
                return newid;
            }
        }


        public List<AdjustmentVoucher> findAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = dbcontext.AdjustmentVouchers.Include(m => m.InitiatedClerk)
                .Include(m => m.ApprovedSup)
                .Include(m => m.ApprovedMgr)
                .Include(m => m.AdjustmentVoucherDetails)
                .ToList();
            return advlist;
        }

        public AdjustmentVoucher findAdjustmentVoucherById(string id)
        {
            try
            {
                AdjustmentVoucher av = dbcontext.AdjustmentVouchers.Include(m => m.AdjustmentVoucherDetails).ThenInclude(m => m.Product)
                .Include(m => m.ApprovedSup)
                .Include(m => m.ApprovedMgr)
                .Include(m => m.InitiatedClerk)
                .FirstOrDefault(m => m.Id == id);
                if (av == null)
                {
                    throw new Exception();
                }

                return av;
            }
            catch
            {
                throw new Exception("Error finding adjustment voucher by this id");
            }
        }


        public bool SupervisorUpdateAdjustmentVoucherApprovals(AdjustmentVoucher av)
        {
            try
            {
                var original = dbcontext.AdjustmentVouchers.Find(av.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                //dbcontext.Entry(original).CurrentValues.SetValues(av);
                original.Status = av.Status;
                original.Reason = av.Reason;
                original.ApprovedSupId = av.ApprovedSupId;
                original.ApprovedSupDate = av.ApprovedSupDate;
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error approving adjustment voucher by supervisor");
            }
        }
        public bool ManagerUpdateAdjustmentVoucherApprovals(AdjustmentVoucher av)
        {
            try
            {
                var original = dbcontext.AdjustmentVouchers.Find(av.Id);
                if (original == null)
                {
                    throw new Exception();
                }
                //dbcontext.Entry(original).CurrentValues.SetValues(av);
                original.Status = av.Status;
                original.Reason = av.Reason;
                original.ApprovedMgrId = av.ApprovedMgrId;
                original.ApprovedMgrDate = av.ApprovedMgrDate;
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error approving adjustment voucher by manager");
            }
        }

        public void ClerkUpdateAdjustmentVoucherById(string AdjustmentVoucherId)
        {
            try
            {
                AdjustmentVoucher av = findAdjustmentVoucherById(AdjustmentVoucherId);
                if (av == null)
                {
                    throw new Exception();
                }
                av.Status = Status.AdjVoucherStatus.created;
                dbcontext.Update(av);
                dbcontext.SaveChanges();
            }
            catch
            {
                throw new Exception("Error finding adjustment voucher by this id");
            }
        }

        public AdjustmentVoucher ClerkSubmitAdjustmentVoucher(string AdjustmentVoucherId)
        {
            try
            {
                AdjustmentVoucher av = findAdjustmentVoucherById(AdjustmentVoucherId);
                if (av == null)
                {
                    throw new Exception();
                }
                av.Status = Status.AdjVoucherStatus.pendapprov;
                dbcontext.Update(av);
                dbcontext.SaveChanges();
                return av;
            }
            catch
            {
                throw new Exception("Error finding adjustment voucher by this id");
            }

        }

        public List<AdjustmentVoucher> findAdjustmentVoucherByClerkId(int clerkid)
        {
            try
            {
                List<AdjustmentVoucher> avlist = dbcontext.AdjustmentVouchers
                    .Include(m => m.AdjustmentVoucherDetails)
                    .ThenInclude(m => m.Product)
                .Include(m => m.ApprovedSup)
                .Include(m => m.ApprovedMgr)
                .Include(m => m.InitiatedClerk)
                .Where(m => m.InitiatedClerkId == clerkid)
                .ToList();
                if (avlist == null)
                {
                    throw new Exception();
                }
                return avlist;
            }
            catch
            {
                throw new Exception("Error finding adjustment voucher by this clerk id");
            }
        }

        public bool DeleteAdjustmentVoucher(AdjustmentVoucher av)
        {
            AdjustmentVoucher original = dbcontext.AdjustmentVouchers.Where(m => m.Id == av.Id).FirstOrDefault();
            if (original != null)
            {
                dbcontext.AdjustmentVouchers.Remove(original);
            }
            dbcontext.SaveChanges();
            return true;
        }



    }
}

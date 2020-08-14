
﻿using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

﻿using Microsoft.EntityFrameworkCore;
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


        public AdjustmentVoucher saveNewAdjustmentVoucher(AdjustmentVoucher av)
        {
            dbcontext.AdjustmentVouchers.Add(av);
            dbcontext.SaveChanges();
            return av;
        }
        public string createnewid()
        {
            // 029_006_2020
            AdjustmentVoucher lastcreatedvoucher = dbcontext.AdjustmentVouchers.OrderByDescending(x => x.InitiatedDate).Take(1).FirstOrDefault();
            string lastcreatedid = lastcreatedvoucher.Id;

            //string s = lastcreatedid.Substring(4,2);
            //string s1 = lastcreatedid.Substring(8,2);

            int lastnum = int.Parse(lastcreatedid.Substring(0, 3));
            int lastcreatedmonth = int.Parse(lastcreatedid.Substring(4, 3));
            int lastcreatedyear = int.Parse(lastcreatedid.Substring(8, 4));
           

            int num = 001;
            int initiatedatemonth = int.Parse(DateTime.Now.ToString("MM"));
            int initiatedateyear = int.Parse(DateTime.Now.ToString("yyyy"));

            if (lastcreatedmonth == initiatedatemonth && lastcreatedyear == initiatedateyear)
            {
                lastnum++;
                if (lastnum >= 10)
                {
                    string newid = string.Format("0{0}_{1}_{2}", lastnum, lastcreatedid.Substring(4, 3), initiatedateyear);
                    return newid;
                }
                else
                {
                    string newid = string.Format("00{0}_{1}_{2}", lastnum, lastcreatedid.Substring(4, 3), initiatedateyear);
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
                .Include(m=>m.ApprovedMgr)
                .Include(m=>m.AdjustmentVoucherDetails)
                .ToList();
            return advlist;
        }

    }
}

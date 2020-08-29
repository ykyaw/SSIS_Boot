using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.Common;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSIS_BOOT.Repo
{
    public class RetrievalRepo
    {

        private SSISContext dbcontext;
        public RetrievalRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Retrieval GenRetrievalAndReturn(Retrieval r1)
        {
            dbcontext.Retrievals.Add(r1);
            dbcontext.SaveChanges();

            Retrieval r = dbcontext.Retrievals.Include(m => m.Clerk).FirstOrDefault(x => x.Id == r1.Id);
            return r;
        }

        public Retrieval GetRetrieval(long date, int clerkid, string created, string retrieved)
        {
            return dbcontext.Retrievals.Include(m => m.Clerk)
                .Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product).ThenInclude(m=>m.Category)
                .Include(m=> m.RequisitionDetails).ThenInclude(m => m.Requisition)
                .FirstOrDefault(x => x.DisbursedDate == date && x.ClerkId == clerkid && (x.Status == created || x.Status == retrieved));
        }
        public bool UpdateRetrieval(Retrieval r1)
        {
            try
            {
                var original = dbcontext.Retrievals.Find(r1.Id);
                if(original ==null)
                {
                    throw new Exception();
                }
                original.NeedAdjustment = r1.NeedAdjustment;
                original.Remark = r1.Remark;
                original.ClerkId = r1.ClerkId;
                if(r1.RetrievedDate != null)
                {
                    original.RetrievedDate = r1.RetrievedDate;
                }
                if(r1.Status == Status.RetrievalStatus.retrieved)
                {
                    original.Status = r1.Status;
                }
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error updating retrieval form");
            }

        }
        public Retrieval GetRetrievalById(int retrivId)
        {
            return dbcontext.Retrievals.Include(m => m.Clerk)
                .Include(m => m.RequisitionDetails).ThenInclude(m => m.Product).ThenInclude(m => m.Category)
                .Include(m => m.RequisitionDetails).ThenInclude(m => m.Requisition).ThenInclude(m=>m.Department)
                .FirstOrDefault(m=>m.Id == retrivId);
        }

        public List<Retrieval> GetRetrievalThatNeedAdjustmentVoucher(long currentdate)
        {
            long retrievallimit = currentdate - 2592000000; //take current date, minus 30 days (30 * 86400000ms in a day)
            return dbcontext.Retrievals.Where(m => m.NeedAdjustment == true && m.RetrievedDate > retrievallimit).ToList();
        }
        public List<Retrieval> GetAllRetrievals()
        {
            List<Retrieval> retrivlist = dbcontext.Retrievals.Include(m=>m.Clerk).Include(m=>m.RequisitionDetails).ToList();
            return retrivlist;
        }
    }
}

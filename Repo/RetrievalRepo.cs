using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SSIS_BOOT.Common;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RetrievalRepo
    {

        private SSISContext dbcontext;
        public RetrievalRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Retrieval genretrievalandreturn(Retrieval r1)
        {
            dbcontext.Retrievals.Add(r1);
            dbcontext.SaveChanges();

            Retrieval r = dbcontext.Retrievals.Include(m => m.Clerk).FirstOrDefault(x => x.Id == r1.Id);
            return r;
        }

        public Retrieval GetRetrieval(long date, int clerkid, string status)
        {
            return dbcontext.Retrievals.Include(m => m.Clerk)
                .Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product).ThenInclude(m=>m.Category)
                .Include(m=> m.RequisitionDetails).ThenInclude(m => m.Requisition)
                .FirstOrDefault(x => x.DisbursedDate == date && x.ClerkId == clerkid && x.Status == status);
        }
        public bool UpdateRetrieval(Retrieval r1)
        {
            try
            {
                //dbcontext.Retrievals.Update(r1);
                var original = dbcontext.Retrievals.Find(r1.Id);
                if(original ==null)
                {
                    throw new Exception();
                }
                original.NeedAdjustment = r1.NeedAdjustment;
                original.Remark = r1.Remark;
                original.ClerkId = r1.ClerkId;
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
                .Include(m => m.RequisitionDetails).ThenInclude(m => m.Requisition)
                .FirstOrDefault(m=>m.Id == retrivId);
        }
    }
}

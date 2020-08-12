using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
            Retrieval r = dbcontext.Retrievals.Include(m => m.Clerk).OrderByDescending(m=>m.Id).FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);
            return r;
        }

        public Retrieval GetRetrieval(long date)
        {
            return dbcontext.Retrievals.Include(m => m.Clerk)
                .Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product)
                .Include(m=> m.RequisitionDetails).ThenInclude(m => m.Requisition)
                .FirstOrDefault(x => x.DisbursedDate == date);
        }
        public bool UpdateRetrieval(Retrieval r1)
        {
            try
            {
                dbcontext.Retrievals.Update(r1);
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Error updating retrieval form");
            }

        }
    }
}

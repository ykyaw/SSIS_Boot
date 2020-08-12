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
            try //check whether retrieval has already been created. if yes, return earlier retrieval. else create new
            {
                if (dbcontext.Retrievals.FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate) != null) //if i already has a retrieval with this date, throw exception
                {
                    throw new Exception();
                }
                dbcontext.Retrievals.Add(r1);
                dbcontext.SaveChanges();
                return dbcontext.Retrievals.Include(m => m.Clerk).FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);
            }
            catch (Exception) //propagate the exception out 
            {
                throw new Exception();
                //return dbcontext.Retrievals.Include(m => m.Clerk).FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);
            }
        }

        public Retrieval GetRetrieval(Retrieval r1)
        {
            return dbcontext.Retrievals.Include(m => m.Clerk)
                .Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product)
                .Include(m=> m.RequisitionDetails).ThenInclude(m => m.Requisition)
                .Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Retrieval)
                .FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);
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

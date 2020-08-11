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

        public Retrieval genretrievalandreturn(Retrieval r1, int clerkid)
        {
            try //check whether retrieval has already been created. if yes, return earlier retrieval. else create new
            {
                if (dbcontext.Retrievals.FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate) != null)
                {
                    throw new Exception();
                }
                dbcontext.Retrievals.Add(r1);
                dbcontext.SaveChanges();
                return dbcontext.Retrievals.FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);

            }
            catch (Exception)
            {
                return dbcontext.Retrievals.FirstOrDefault(x => x.DisbursedDate == r1.DisbursedDate);
            }

        }
    }
}

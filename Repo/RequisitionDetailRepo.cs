using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RequisitionDetailRepo
    {
        private SSISContext dbcontext;
        public RequisitionDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public RequisitionDetail updateretrievalid(RequisitionDetail rd)
        {
            dbcontext.RequisitionDetails.Update(rd);
            dbcontext.SaveChanges();
            return dbcontext.RequisitionDetails.Find(rd.Id);
        }

    }
}

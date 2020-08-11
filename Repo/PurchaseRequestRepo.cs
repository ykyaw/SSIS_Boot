using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class PurchaseRequestRepo
    {
        private SSISContext dbcontext;
        public PurchaseRequestRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<PurchaseRequestDetail> findallpurchasereq()
        {
            List<PurchaseRequestDetail> purreqlist = dbcontext.PurchaseRequestDetails.ToList();
            return purreqlist;
        }
    }
}

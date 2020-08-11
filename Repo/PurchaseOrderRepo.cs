using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class PurchaseOrderRepo
    {
        private SSISContext dbcontext;
        public PurchaseOrderRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<PurchaseOrder> findallpurchaseorder()
        {
            List<PurchaseOrder> polist = dbcontext.PurchaseOrders.ToList();
            return polist;
        }

    }
}

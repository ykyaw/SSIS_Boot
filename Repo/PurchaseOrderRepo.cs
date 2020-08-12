using Microsoft.EntityFrameworkCore;
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
            List<PurchaseOrder> polist = dbcontext.PurchaseOrders.Include(m=>m.CollectionPoint).Include(m=>m.Supplier).Include(m=>m.OrderedByClerk)
                .Include(m=>m.ApprovedBySup).Include(m=>m.ReceivedByClerk).Include(m=> m.PurchaseOrderDetails).ToList();
            return polist;
        }

    }
}

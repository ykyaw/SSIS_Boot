using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class PurchaseOrderDetailRepo
    {
        private SSISContext dbcontext;
        public PurchaseOrderDetailRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<PurchaseOrderDetail> findpodetails(int poId)
        {
            List<PurchaseOrderDetail> podlist = dbcontext.PurchaseOrderDetails.Where(m => m.PurchaseOrderId == poId).ToList();
            return podlist;
        }
    }
}

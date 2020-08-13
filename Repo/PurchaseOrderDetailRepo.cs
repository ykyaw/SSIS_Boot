using Microsoft.EntityFrameworkCore;
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
            List<PurchaseOrderDetail> podlist = dbcontext.PurchaseOrderDetails.Include(m=>m.PurchaseOrder).ThenInclude(m=>m.Supplier)
                .Include(m => m.PurchaseOrder).ThenInclude(m=>m.CollectionPoint)
                .Include(m=> m.PurchaseRequestDetail).Include(m => m.Product).Where(m => m.PurchaseOrderId == poId).ToList();
            return podlist;
        }

        public bool Updatepurchaseorderdetail(PurchaseOrderDetail pod)
        {
            var original = dbcontext.PurchaseOrderDetails.Find(pod.Id);
            if (original == null)
            {
                throw new Exception();
            }
            dbcontext.Entry(original).CurrentValues.SetValues(pod);
            dbcontext.SaveChanges();
            return true;
        }
    }
}

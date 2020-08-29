using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSIS_BOOT.Repo
{
    public class PurchaseOrderRepo
    {
        private SSISContext dbcontext;
        public PurchaseOrderRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<PurchaseOrder> FindAllPurchaseOrder()
        {
            List<PurchaseOrder> polist = dbcontext.PurchaseOrders.Include(m => m.CollectionPoint).Include(m => m.Supplier).Include(m => m.OrderedByClerk)
                .Include(m => m.ApprovedBySup).Include(m => m.PurchaseOrderDetails).ToList();
            return polist;
        }

        public PurchaseOrder Create(PurchaseOrder po)
        {
            dbcontext.PurchaseOrders.Add(po);
            dbcontext.SaveChanges();
            int id = po.Id;

            PurchaseOrder newpo = dbcontext.PurchaseOrders.FirstOrDefault(m => m.Id == id);
            return newpo;
        }

        public PurchaseOrder FindPOByPOid(int po_id)
        {
            return dbcontext.PurchaseOrders.Include(m=>m.PurchaseOrderDetails).Where(m=>m.Id == po_id).FirstOrDefault();
        }
        public bool UpdatePoStatus(PurchaseOrder po)
        {
            var original = dbcontext.PurchaseOrders.Find(po.Id);
            if (original == null)
            {
                throw new Exception();
            }
            original.Status = po.Status;
            dbcontext.SaveChanges();
            return true;
        }

    }

}


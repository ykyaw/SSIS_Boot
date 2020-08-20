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
            List<PurchaseOrder> polist = dbcontext.PurchaseOrders.Include(m => m.CollectionPoint).Include(m => m.Supplier).Include(m => m.OrderedByClerk)
                .Include(m => m.ApprovedBySup).Include(m => m.PurchaseOrderDetails).ToList();
            return polist;
        }
        //public PurchaseOrder create(PurchaseOrder po, int clerkid, string supplierid, long ordereddate, int collectionpointid,double totalprice)
        //{
        //    po.OrderedByClerkId = clerkid;
        //    po.SupplierId = supplierid;
        //    po.OrderedDate = ordereddate;
        //    po.CollectionPointId = collectionpointid;
        //    po.TotalPrice = totalprice;
        //    dbcontext.PurchaseOrders.Add(po);
        //    dbcontext.SaveChanges();
        //    int id = po.Id;

        //    PurchaseOrder newpo = dbcontext.PurchaseOrders.FirstOrDefault(m => m.Id == id);
        //    return newpo;
        //}


        public PurchaseOrder create(PurchaseOrder po)
        {
            dbcontext.PurchaseOrders.Add(po);
            dbcontext.SaveChanges();
            int id = po.Id;

            PurchaseOrder newpo = dbcontext.PurchaseOrders.FirstOrDefault(m => m.Id == id);
            return newpo;
        }
        public PurchaseOrder addpodinPO(List<PurchaseRequestDetail> List_of_PRD_toaddinPO, int poid)
        {
            foreach (PurchaseRequestDetail prd in List_of_PRD_toaddinPO)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.PurchaseOrderId = poid;
                pod.PurchaseRequestDetailId = prd.Id;
                pod.ProductId = prd.ProductId;
                pod.QtyPurchased = prd.ReorderQty;
                pod.TotalPrice = prd.TotalPrice;
                dbcontext.PurchaseOrderDetails.Add(pod);
                dbcontext.SaveChanges();
            }
            PurchaseOrder po = dbcontext.PurchaseOrders.Include(m => m.CollectionPoint).Include(m => m.Supplier).Include(m => m.OrderedByClerk)
                .Include(m => m.ApprovedBySup).Include(m => m.PurchaseOrderDetails).Where(m => m.Id == poid).FirstOrDefault();
            return po;
        }

        public PurchaseOrder findPObyPOid(int po_id)
        {
            return dbcontext.PurchaseOrders.Find(po_id);
        }

        public bool updatePoStatus(PurchaseOrder po)
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


using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SSIS_BOOT.Repo
{
    public class PurchaseRequestRepo
    {
        private SSISContext dbcontext;
        public PurchaseRequestRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<PurchaseRequestDetail> FindAllPurchaseReq()
        {
            List<PurchaseRequestDetail> purreqlist = dbcontext.PurchaseRequestDetails.Include(m=>m.Product).Include(m=>m.CreatedByClerk)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).ToList();
            return purreqlist;
        }

        public List<PurchaseRequestDetail> FindPurchaseReq(long prid)
        {
            List<PurchaseRequestDetail> purreqlist = dbcontext.PurchaseRequestDetails.Include(m => m.Product).Include(m => m.CreatedByClerk)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).Where(m=>m.PurchaseRequestId == prid).ToList();
            return purreqlist;
        }

        public bool AddNewPurchaseRequestDetail(PurchaseRequestDetail prd1)
        {
            dbcontext.PurchaseRequestDetails.Add(prd1);
            dbcontext.SaveChanges();
            return true;
        }

        public List<PurchaseRequestDetail> GetCurrentPurchaseRequest (long purchaserequestId)
        {
            List<PurchaseRequestDetail> prrequest = dbcontext.PurchaseRequestDetails.Include(m => m.CreatedByClerk).Include(m => m.Product)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).Where(m => m.PurchaseRequestId == purchaserequestId).ToList();
            return prrequest;
        }
        public PurchaseRequestDetail UpdatePurchaseRequestItem(PurchaseRequestDetail prd)
        {
            var original = dbcontext.PurchaseRequestDetails.Find(prd.Id);
            if (original == null)
            {
                throw new Exception();
            }
            original.ReorderQty = prd.ReorderQty;
            original.SupplierId = prd.SupplierId;
            original.VenderQuote = prd.VenderQuote;
            original.TotalPrice = prd.TotalPrice;
            original.Status = prd.Status;
            original.SubmitDate = prd.SubmitDate;
            original.Remarks = prd.Remarks;
            dbcontext.SaveChanges();
            return original;
        }
        public bool UpdateApprovedPrItems(PurchaseRequestDetail prd, int supid, long approveddate)
        {
            var original = dbcontext.PurchaseRequestDetails.Find(prd.Id);
            if (original == null)
            {
                throw new Exception();
            }
            original.Remarks = prd.Remarks;
            original.Status = prd.Status;
            original.ApprovedBySupId = supid;
            original.ApprovedDate = approveddate;         
            dbcontext.SaveChanges();
            return true;
        }
        public bool DeleteCreatedPurchaseRequest(PurchaseRequestDetail prd)
        {
            PurchaseRequestDetail original = dbcontext.PurchaseRequestDetails.Where(m => m.Id == prd.Id).FirstOrDefault();
            if (original != null)
            {
                dbcontext.PurchaseRequestDetails.Remove(original);
            }
            dbcontext.SaveChanges();
            return true;
        }
    }
}

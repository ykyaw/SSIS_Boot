using Microsoft.EntityFrameworkCore;
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
            List<PurchaseRequestDetail> purreqlist = dbcontext.PurchaseRequestDetails.Include(m=>m.Product).Include(m=>m.CreatedByClerk)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).ToList();
            return purreqlist;
        }

        public List<PurchaseRequestDetail> findpurchasereq(long prid)
        {
            List<PurchaseRequestDetail> purreqlist = dbcontext.PurchaseRequestDetails.Include(m => m.Product).Include(m => m.CreatedByClerk)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).Where(m=>m.PurchaseRequestId == prid).ToList();
            return purreqlist;
        }

        public bool addnewpurchaserequestdetail(PurchaseRequestDetail prd1)
        {
            dbcontext.PurchaseRequestDetails.Add(prd1);
            dbcontext.SaveChanges();
            return true;
        }

        public List<PurchaseRequestDetail> getcurrentpurchaserequest (long purchaserequestId)
        {
            List<PurchaseRequestDetail> prrequest = dbcontext.PurchaseRequestDetails.Include(m => m.CreatedByClerk).Include(m => m.Product)
                .Include(m => m.Supplier).Include(m => m.ApprovedBySup).Where(m => m.PurchaseRequestId == purchaserequestId).ToList();
            return prrequest;
        }

        public bool updatepurchaserequestitem(PurchaseRequestDetail prd)
        {
            var original = dbcontext.PurchaseRequestDetails.Find(prd.Id);
            if (original == null)
            {
                throw new Exception();
            }
            dbcontext.Entry(original).CurrentValues.SetValues(prd);
            dbcontext.SaveChanges();
            return true;
        }
        public bool updateapprovedpritems(PurchaseRequestDetail prd, int supid, long approveddate)
        {
            var original = dbcontext.PurchaseRequestDetails.Find(prd.Id);
            if (original == null)
            {
                throw new Exception();
            }
            prd.ApprovedBySupId = supid;
            prd.ApprovedDate = approveddate;
            dbcontext.Entry(original).CurrentValues.SetValues(prd);
            dbcontext.SaveChanges();
            return true;
        }
    }
}

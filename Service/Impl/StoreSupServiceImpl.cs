using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class StoreSupServiceImpl : IStoreSupService
    {
        public AdjustmentVoucherRepo avrepo;
        public EmployeeRepo erepo;
        public PurchaseRequestRepo purreqrepo;
        public PurchaseOrderRepo porepo;

        public StoreSupServiceImpl(AdjustmentVoucherRepo avrepo, EmployeeRepo erepo, PurchaseRequestRepo purreqrepo, PurchaseOrderRepo porepo)
        {
            this.avrepo = avrepo;
            this.erepo = erepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
        }

        public AdjustmentVoucher getAdjVouchById(string id)
        {
            AdjustmentVoucher av = avrepo.findAdjustmentVoucherById(id);
            return av;
        }

        public bool ApprovRejAdjustmentVoucher(AdjustmentVoucher av, int approvalId)
        {
            Employee emp = erepo.findempById(approvalId);
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long date = dt.ToUnixTimeMilliseconds();
            try
            {
                if (emp.Role == "sm")   //persist to correct column based on supervisor or manager role
                {
                    av.ApprovedMgrId = emp.Id;
                    av.ApprovedMgrDate = date;
                    avrepo.updateAdjustmentVoucherApprovals(av);
                }
                if (emp.Role == "ss")
                {
                    av.ApprovedSupId = emp.Id;
                    av.ApprovedSupDate = date;
                    avrepo.updateAdjustmentVoucherApprovals(av);
                }
                if (av.Status == Status.AdjVoucherStatus.pendmanapprov)
                {
                    //SEND MANAGER EMAIL TO BE FOLLOWED UP
                    //SEND EMAIL TO ALL TO BE FOLLOWED UP
                }
                return true;
            }
            catch (Exception m)
            {
                throw m;
            }
        }

        public List<PurchaseRequestDetail> getpurchasereq()
        {
            return purreqrepo.findallpurchasereq();
        }
        public List<PurchaseRequestDetail> getprdetails(long prid)
        {
            return purreqrepo.findpurchasereq(prid);
        }
        //public bool updatepr(List<PurchaseRequestDetail> prdlist)
        //{
        //    foreach (PurchaseRequestDetail prd in prdlist)
        //    {
        //        purreqrepo.updatepurchaserequestitem(prd);
        //    }
        //    if (prdlist[0].Status == Status.PurchaseRequestStatus.approved)
        //    {

        //        List<PurchaseRequestDetail> sortedprlist = prdlist.GroupBy(m => m.SupplierId).SelectMany(m => m).ToList();
        //        Dictionary<string, List<PurchaseRequestDetail>> pdict = new Dictionary<string, List<PurchaseRequestDetail>>();

        //        foreach (PurchaseRequestDetail prd in sortedprlist)
        //        {
        //            if (!pdict.ContainsKey(prd.SupplierId))
        //            {
        //                List<PurchaseRequestDetail> prdlist1 = new List<PurchaseRequestDetail>();
        //                prdlist1.Add(prd);
        //                pdict.Add(prd.SupplierId, prdlist1);
        //            }
        //            else
        //            {
        //                //List<PurchaseRequestDetail> prdlist2 = pdict[prd.SupplierId];
        //                pdict[prd.SupplierId].Add(prd);
        //                //pdict[prd.SupplierId] = prdlist2;
        //            }
        //        }
        //        foreach (var r in pdict)
        //        {
        //            PurchaseOrder po = new PurchaseOrder() { };
        //            porepo.create(po);
        //            }
        //    }
        //    else
        //    {
        //        //send email on rejected purchaserequest with remarks
        //    }
        //    return true;
        //}

    }
}

using SSIS_BOOT.Common;
using SSIS_BOOT.Email;
using SSIS_BOOT.Email.EmailTemplates;
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
        private AdjustmentVoucherRepo avrepo;
        private EmployeeRepo erepo;
        private PurchaseRequestRepo purreqrepo;
        private PurchaseOrderRepo porepo;
        private SupplierRepo srepo;
        private CollectionPointRepo crepo;

        public StoreSupServiceImpl(AdjustmentVoucherRepo avrepo, EmployeeRepo erepo, PurchaseRequestRepo purreqrepo, PurchaseOrderRepo porepo, SupplierRepo srepo, CollectionPointRepo crepo)
        {
            this.avrepo = avrepo;
            this.erepo = erepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
            this.srepo = srepo;
            this.crepo = crepo;
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
        public bool updatepr(List<PurchaseRequestDetail> prdlist, int supid, long approveddate)
        {
            foreach (PurchaseRequestDetail prd in prdlist)
            {
                purreqrepo.updateapprovedpritems(prd, supid, approveddate);
            }

            if (prdlist[0].Status == Status.PurchaseRequestStatus.approved)
            {

                List<PurchaseRequestDetail> sortedprlist = prdlist.GroupBy(m => m.SupplierId).SelectMany(m => m).ToList();
                Dictionary<string, List<PurchaseRequestDetail>> pdict = new Dictionary<string, List<PurchaseRequestDetail>>();

                foreach (PurchaseRequestDetail prd in sortedprlist)
                {
                    if (!pdict.ContainsKey(prd.SupplierId))
                    {
                        List<PurchaseRequestDetail> prdlist1 = new List<PurchaseRequestDetail>();
                        prdlist1.Add(prd);
                        pdict.Add(prd.SupplierId, prdlist1);
                    }
                    else
                    {
                        //List<PurchaseRequestDetail> prdlist2 = pdict[prd.SupplierId];
                        pdict[prd.SupplierId].Add(prd);
                        //pdict[prd.SupplierId] = prdlist2;
                    }
                }

                foreach (var r in pdict) //for each string in the dictionary
                {
                    PurchaseOrder po = new PurchaseOrder();
                    int clerkid = r.Value[0].CreatedByClerkId;
                    string supplierid = r.Value[0].SupplierId;
                    long ordereddate = approveddate;
                    string status = Status.PurchaseOrderStatus.approved;
                    int collectionpointid = crepo.getstorecollectionpoint().Id;
                    double totalprice = 0;
                    foreach(PurchaseRequestDetail pr in pdict[r.Key])
                    {
                        totalprice += pr.TotalPrice;
                    }
                    PurchaseOrder newpo = porepo.create(po, clerkid, supplierid, ordereddate, status, collectionpointid, totalprice);
                    List<PurchaseRequestDetail> List_of_PRD_toaddinPO = pdict[r.Key];
                    newpo = porepo.addpodinPO(List_of_PRD_toaddinPO, newpo.Id);

                    Employee clerk = erepo.findempById(r.Value[0].CreatedByClerkId);
                    Supplier supplier = srepo.findsupplierbyId(r.Value[0].SupplierId);
                    //EmailModel email = new EmailModel();

                    //Task.Run(async () =>
                    //{
                    //    EmailTemplates.ApprovePOtemplate rfq = new EmailTemplates.ApprovePOtemplate(clerk, supplier, newpo);
                    //    email.emailTo = supplier.Email;
                    //    email.emailSubject = rfq.subject;
                    //    email.emailBody = rfq.body;
                    //    await mailservice.SendRFQEmailAsync(email, clerk);
                    //}
                }
            }

            else //when rejected
            {
                string remarks = prdlist[0].Remarks; //reason for rejection
                //add email to reject 
            }
            return true;
        }


        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            return avrepo.findAllAdjustmentVoucher();
        }

    }
}

using SSIS_BOOT.Common;
using SSIS_BOOT.Email;
using SSIS_BOOT.Email.EmailTemplates;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
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
        protected IMailer mailservice;
        private PurchaseOrderDetailRepo podrepo;
        private TransactionRepo trepo;

        public StoreSupServiceImpl(AdjustmentVoucherRepo avrepo, EmployeeRepo erepo, PurchaseRequestRepo purreqrepo,
            PurchaseOrderRepo porepo, SupplierRepo srepo, CollectionPointRepo crepo, IMailer mailservice, PurchaseOrderDetailRepo podrepo, TransactionRepo trepo)
        {
            this.avrepo = avrepo;
            this.erepo = erepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
            this.srepo = srepo;
            this.crepo = crepo;
            this.mailservice = mailservice;
            this.podrepo = podrepo;
            this.trepo = trepo;
        }

        public AdjustmentVoucher GetAdjVouchById(string id)
        {
            AdjustmentVoucher av = avrepo.FindAdjustmentVoucherById(id);
            return av;
        }

        public bool ApprovRejAdjustmentVoucher(AdjustmentVoucher av, int approvalId)
        {
            Employee emp = erepo.FindEmpById(approvalId);
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long date = dt.ToUnixTimeMilliseconds();
            try
            {
                if (emp.Role == "sm")   //persist to correct column based on supervisor or manager role
                {
                    av.ApprovedMgrId = emp.Id;
                    av.ApprovedMgrDate = date;
                    //For all approvals by manager, it will jump to final state of "approved"
                    if (av.Status != Status.AdjVoucherStatus.rejected)
                    {
                        av.Status = Status.AdjVoucherStatus.approved;
                    }
                    avrepo.ManagerUpdateAdjustmentVoucherApprovals(av);
                }
                if (emp.Role == "ss")
                {
                    av.ApprovedSupId = emp.Id;
                    av.ApprovedSupDate = date;
                    avrepo.SupervisorUpdateAdjustmentVoucherApprovals(av);
                }

                if (av.Status == Status.AdjVoucherStatus.pendmanapprov)
                {
                    AdjustmentVoucher av1 = avrepo.FindAdjustmentVoucherById(av.Id);
                    Employee manager = erepo.FindSupervisorByEmpId(emp.Id);
                    Employee sup = erepo.FindEmpById(emp.Id);
                    EmailModel email = new EmailModel();

                    Task.Run(async () =>
                    {
                        EmailTemplates.PendingManagerApprovalAVTemplate apt = new EmailTemplates.PendingManagerApprovalAVTemplate(av1, manager, sup);
                        email.emailTo = manager.Email;
                        email.emailSubject = apt.subject;
                        email.emailBody = apt.body;
                        await mailservice.SendEmailAsync(email);
                    });
                }
                else //approved or rejected
                {
                    AdjustmentVoucher av1 = avrepo.FindAdjustmentVoucherById(av.Id);

                    if (av1.Status == Status.AdjVoucherStatus.approved) //new method for auto update of stock card upon approved adjustment vouchers
                    {
                        UpdateStockCardForApprovedAdjustmentVoucher(av1);
                    }
                    Employee clerk = erepo.FindEmpById(av1.InitiatedClerkId);
                    Employee sup = erepo.FindEmpById((int)clerk.ManagerId);
                    Employee manager = erepo.FindEmpById((int)sup.ManagerId);
                    List<Employee> elist = new List<Employee>(); //Regardless of approval hierarchy or who approved, as long as its in final state of approved or rejected, clerk + supervisor + manager will get email
                    elist.Add(sup);
                    elist.Add(manager);
                    EmailModel email = new EmailModel();
                    Task.Run(async () =>
                    {
                        EmailTemplates.ApproveRejectAVTemplate apt = new EmailTemplates.ApproveRejectAVTemplate(av1, clerk, sup);
                        email.emailTo = clerk.Email;
                        email.emailSubject = apt.subject;
                        email.emailBody = apt.body;

                        await mailservice.SendEmailwithccallAsync(email, elist);
                    });
                }

                return true;
            }
            catch (Exception m)
            {
                throw m;
            }
        }

        public bool UpdateStockCardForApprovedAdjustmentVoucher(AdjustmentVoucher a)
        {
            AdjustmentVoucher av = avrepo.FindAdjustmentVoucherById(a.Id);
            List<AdjustmentVoucherDetail> avd = av.AdjustmentVoucherDetails;
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long dateofadj = dt.ToUnixTimeMilliseconds();

            foreach (AdjustmentVoucherDetail i in avd)
            {
                Transaction t_new = new Transaction();
                t_new.ProductId = i.ProductId;
                t_new.Date = dateofadj;
                StringBuilder builder = new StringBuilder();
                t_new.Description = builder.Append("Approved Adjustment Voucher due to ").Append(i.Reason).ToString();
                t_new.Qty = i.QtyAdjusted;
                Transaction t_old = trepo.GetLatestTransactionByProductId(i.ProductId);
                t_new.Balance = t_old.Balance + t_new.Qty;
                if (t_new.Balance <= 0)
                {
                    t_new.Balance = 0;
                }
                t_new.UpdatedByEmpId = av.InitiatedClerkId;
                t_new.RefCode = "AV ID: " + av.Id.ToString();
                trepo.SaveNewTransaction(t_new);
            }
            return true;
        }


        public List<PurchaseRequestDetail> GetPurchaseReq()
        {
            return purreqrepo.FindAllPurchaseReq();
        }
        public List<PurchaseRequestDetail> GetPrDetails(long prid)
        {
            return purreqrepo.FindPurchaseReq(prid);
        }
        public bool UpdatePr(List<PurchaseRequestDetail> prdlist, int supid, long approveddate)
        {
            foreach (PurchaseRequestDetail prd in prdlist)
            {
                purreqrepo.UpdateApprovedPrItems(prd, supid, approveddate);
            }

            if (prdlist[0].Status == Status.PurchaseRequestStatus.approved)
            {

                List<PurchaseRequestDetail> prdlist2 = purreqrepo.FindPurchaseReq(prdlist[0].PurchaseRequestId); //getting back all the PurchaseRequestDetail with extra information for Emailing
                List<PurchaseRequestDetail> sortedprlist = prdlist2.GroupBy(m => m.SupplierId).SelectMany(m => m).ToList();
                Dictionary<string, List<PurchaseRequestDetail>> pdict = new Dictionary<string, List<PurchaseRequestDetail>>(); //create dictionary of supplier Id as key, and List<PRD> as value for further creation of PO

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

                foreach (var r in pdict) //for each supplierId in the dictionary, create PO
                {
                    PurchaseOrder po = new PurchaseOrder();
                    po.OrderedByClerkId = r.Value[0].CreatedByClerkId;
                    po.SupplierId = r.Value[0].SupplierId;
                    po.OrderedDate = approveddate;
                    po.Status = Status.PurchaseOrderStatus.pending;
                    po.CollectionPointId = crepo.GetStoreCollectionPoint().Id;
                    po.ApprovedBySupId = supid;
                    po.SupplyByDate = approveddate + 604800000; //Add 7 days to ordered date
                    double totalprice = 0;
                    foreach (PurchaseRequestDetail pr in pdict[r.Key])
                    {
                        totalprice += pr.TotalPrice;
                    }
                    po.TotalPrice = totalprice;
                    PurchaseOrder newpo = porepo.Create(po);
                    List<PurchaseRequestDetail> List_of_PRD_toaddinPO = pdict[r.Key];
                    foreach (PurchaseRequestDetail z in List_of_PRD_toaddinPO)
                    {
                        PurchaseOrderDetail pod = new PurchaseOrderDetail();
                        pod.PurchaseOrderId = newpo.Id;
                        pod.PurchaseRequestDetailId = z.Id;
                        pod.ProductId = z.ProductId;
                        pod.QtyPurchased = z.ReorderQty;
                        pod.TotalPrice = z.TotalPrice;
                        pod.Status = Status.PurchaseOrderDetailStatus.pending;
                        podrepo.CreatePurchaseOrderDetail(pod);
                    }

                    PurchaseOrder savedpo = porepo.FindPOByPOid(newpo.Id); //Latest PO after persisting
                    List<PurchaseOrderDetail> savedpod = podrepo.FindPoDetails(savedpo.Id); //Latest POD after persisting 
                    Employee clerk = erepo.FindEmpById(r.Value[0].CreatedByClerkId);
                    Supplier supplier = srepo.FindSupplierById(r.Value[0].SupplierId);
                    EmailModel email = new EmailModel();
                    Task.Run(async () =>
                    {
                        EmailTemplates.ApprovedPRtemplate apt = new EmailTemplates.ApprovedPRtemplate(clerk, supplier, savedpod, savedpo);
                        email.emailTo = supplier.Email;
                        email.emailSubject = apt.subject;
                        email.emailBody = apt.body;
                        await mailservice.SendEmailwithccAsync(email, clerk);
                    });
                }
            }

            else //when rejected
            {
                // to pull out purchase request id and date
                List<PurchaseRequestDetail> prdlist2 = purreqrepo.FindPurchaseReq(prdlist[0].PurchaseRequestId); //getting back all the PurchaseRequestDetail with extra information for Emailing
                long submitdate = (long)prdlist2[0].SubmitDate;
                int prid = prdlist2[0].Id;
                string remarks = prdlist2[0].Remarks;
                Employee clerk = erepo.FindEmpById(prdlist2[0].CreatedByClerkId);
                Employee sup = erepo.FindEmpById(supid);
                EmailModel email = new EmailModel();
                Task.Run(async () =>
                {
                    EmailTemplates.RejectedPRtemplate apt = new EmailTemplates.RejectedPRtemplate(clerk, sup, prid, submitdate, remarks);
                    email.emailTo = clerk.Email;
                    email.emailSubject = apt.subject;
                    email.emailBody = apt.body;
                    await mailservice.SendEmailAsync(email);
                });
            }
            return true;
        }
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher()
        {
            return avrepo.FindAllAdjustmentVoucher();
        }

    }
}

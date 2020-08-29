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
 * @author Choo Teck Kian, Pei Jia En, Jade Lim, Guo Xiujuan
 */
namespace SSIS_BOOT.Service.Impl
{
    public class StoreClerkServiceImpl : IStoreClerkService
    {
        private ProductRepo prepo;
        private PurchaseRequestRepo purreqrepo;
        private PurchaseOrderRepo porepo;
        private PurchaseOrderDetailRepo podrepo;
        private RequisitionRepo rrepo;
        private RequisitionDetailRepo rdrepo;
        private TransactionRepo trepo;
        private RetrievalRepo retrivrepo;
        private TenderQuotationRepo tqrepo;
        private EmployeeRepo erepo;
        private SupplierRepo srepo;
        protected IMailer mailservice;
        private AdjustmentVoucherRepo avrepo;
        private DepartmentRepo drepo;
        private AdjustmentVoucherDetailRepo avdetrepo;

        public StoreClerkServiceImpl(ProductRepo prepo, PurchaseRequestRepo purreqrepo, PurchaseOrderRepo porepo, PurchaseOrderDetailRepo podrepo,
            RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, TransactionRepo trepo, TenderQuotationRepo tqrepo, RetrievalRepo retrivrepo,
            EmployeeRepo erepo, SupplierRepo srepo, IMailer mailservice, AdjustmentVoucherRepo avrepo, DepartmentRepo drepo, AdjustmentVoucherDetailRepo avdetrepo)
        {
            this.prepo = prepo;
            this.purreqrepo = purreqrepo;
            this.porepo = porepo;
            this.podrepo = podrepo;
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.trepo = trepo;
            this.retrivrepo = retrivrepo;
            this.tqrepo = tqrepo;
            this.erepo = erepo;
            this.srepo = srepo;
            this.mailservice = mailservice;
            this.avrepo = avrepo;
            this.drepo = drepo;
            this.avdetrepo = avdetrepo;
        }
        public List<Product> GetAllCat()
        {
            return prepo.FindAllCat();
        }
        public List<Transaction> GetLatestTransaction(List<Product> pdt)
        {
            List<Transaction> tlist = new List<Transaction>();
            foreach (Product p in pdt)
            {
                Transaction t = trepo.GetLatestTransactionByProductId(p.Id);
                if (t == null)
                {
                    t = new Transaction();
                    t.ProductId = p.Id;
                    t.Balance = 0;
                    t.Description = "No record of transaction in stock card for " + p.Id;
                }
                tlist.Add(t);
            }
            return tlist;
        }
        public List<PurchaseOrderDetail> GetPodDetails(int poId)
        {
            return podrepo.FindPoDetails(poId);
        }
        public List<PurchaseOrder> GetPurchaseOrders()
        {
            return porepo.FindAllPurchaseOrder();
        }
        public List<PurchaseRequestDetail> GetPurchaseReq()
        {
            return purreqrepo.FindAllPurchaseReq();
        }
        public Requisition GetReqByReqId(int reqid)
        {
            return rrepo.FindReqFormByReqID(reqid);
        }
        public List<PurchaseRequestDetail> GetPrDetails(long prid)
        {
            return purreqrepo.FindPurchaseReq(prid);
        }
        public bool GenerateQuoteFromPr(List<PurchaseRequestDetail> prdlist, int clerkid)
        {
            List<PurchaseRequestDetail> prdlistwithnull = new List<PurchaseRequestDetail>();

            foreach (PurchaseRequestDetail prd in prdlist)
            {
                if (prd.VenderQuote == null || prd.VenderQuote == "")
                {
                    prdlistwithnull.Add(prd);
                }
            }
            if (prdlistwithnull.Count() < 1)
            {
                return true;
            }
            else
            {
                List<PurchaseRequestDetail> pnull = prdlistwithnull.OrderBy(m => m.SupplierId).ToList();
                Dictionary<string, List<PurchaseRequestDetail>> pdict = new Dictionary<string, List<PurchaseRequestDetail>>();

                foreach (PurchaseRequestDetail prd in pnull)
                {
                    prd.Product = prepo.FindProductById(prd.ProductId);
                    if (!pdict.ContainsKey(prd.SupplierId))
                    {
                        List<PurchaseRequestDetail> prdlist1 = new List<PurchaseRequestDetail>();
                        prdlist1.Add(prd);
                        pdict.Add(prd.SupplierId, prdlist1);
                    }
                    else
                    {
                        pdict[prd.SupplierId].Add(prd);
                    }
                }
                foreach (var r in pdict)
                {
                    Supplier supplier = srepo.FindSupplierById(r.Value[0].SupplierId);
                    Employee clerk = erepo.FindEmpById(clerkid);
                    EmailModel email = new EmailModel();
                    List<PurchaseRequestDetail> List_of_PR_tosend = pdict[r.Key];
                    Task.Run(async () =>
                    {
                        EmailTemplates.RequestQuoteTemplate rfq = new EmailTemplates.RequestQuoteTemplate(clerk, supplier, List_of_PR_tosend);
                        email.emailTo = supplier.Email;
                        email.emailSubject = rfq.subject;
                        email.emailBody = rfq.body;
                        await mailservice.SendRFQEmailAsync(email, clerk);
                    });
                }
            }
            return true;
        }
        public List<Requisition> GetAllReqForm()
        {
            List<Requisition> lr = rrepo.FindAllReqForm();
            List<Requisition> lr2 = new List<Requisition>();

            foreach (Requisition r in lr) //clerk should only be able to see all those requisitio after approved status
            {
                if (r.Status == Status.RequsitionStatus.approved || r.Status == Status.RequsitionStatus.confirmed || r.Status == Status.RequsitionStatus.received || r.Status == Status.RequsitionStatus.completed)
                {
                    lr2.Add(r);
                }
            }
            return lr2;
        }
        public List<Requisition> GetAllReqFormByDateAndStatus(long date, int clerkid, string reqStatus)
        {
            return rrepo.FindRequsitionByCollectionDateAndStatus(date, clerkid, reqStatus);
        }

        public List<Requisition> GetReqFormByDeptId(string deptID)
        {
            List<Requisition> lr = rrepo.FindReqFormByDeptID(deptID);
            List<Requisition> lr2 = new List<Requisition>();
            foreach (Requisition r in lr) //clerk should only be able to see all those requisitio after approved status
            {
                if (r.Status == Status.RequsitionStatus.approved || r.Status == Status.RequsitionStatus.confirmed || r.Status == Status.RequsitionStatus.received || r.Status == Status.RequsitionStatus.completed)
                {
                    lr2.Add(r);
                }
            }
            return lr2;
        }
        public List<Transaction> RetrieveStockcard(string productId)
        {
            return trepo.RetrieveStockcard(productId);
        }
        public Retrieval GenRetrievalForm(long date, int clerkid, List<Requisition> listreq)
        {
            List<RequisitionDetail> rdlnew = new List<RequisitionDetail>();
            Retrieval r_exist = retrivrepo.GetRetrieval(date, clerkid, Status.RetrievalStatus.created, Status.RetrievalStatus.retrieved); // check if there already exist a retrieval with "created" or retrieved status and processed by clerkid
            if (r_exist != null) //If an existing retrieval form for the collection date has been created, update existing requisition with same date with the existing retrievalformId 
            {
                if (r_exist.Status == Status.RetrievalStatus.created)
                {
                    foreach (Requisition re in listreq)//listreq is passed in from controller, which is a list of requisition with "confirmed" status, on the selected date and processed by the clerk in session
                    {
                        foreach (RequisitionDetail detail in re.RequisitionDetails)
                        {
                            detail.RetrievalId = r_exist.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
                            RequisitionDetail x = rdrepo.UpdateRetrievalId(detail); //and update the requisition details, then return it back                    
                        }
                    }
                    Retrieval updatedRetrieval = retrivrepo.GetRetrievalById(r_exist.Id); //Get back the latest created retrieval with all the related objects
                    updatedRetrieval.RequisitionDetails = updatedRetrieval.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
                    return updatedRetrieval;
                }
                if (r_exist.Status == Status.RetrievalStatus.retrieved) //if status is finalized, check for new entries differing from existing retrieval form return the finalized retrieval so don't double create
                {

                    foreach (Requisition r in listreq)
                    {
                        foreach (RequisitionDetail rd in r.RequisitionDetails)
                        {
                            if (!r_exist.RequisitionDetails.Contains(rd)) //if status is fnalised and new entries matches retrieved form, return retrieved form
                            {
                                rdlnew.Add(rd); //else if there are new items in addition to previously retrieved, add to a list for follow up
                            }
                        }
                    }
                    if (rdlnew.Count == 0 || rdlnew == null) //if no new item to follow up, return the original retrieved form. else, pass on the new items to next block for follow up
                    {
                        return r_exist;
                    }
                }
            }
            Retrieval r1 = new Retrieval();
            r1.ClerkId = clerkid;
            r1.DisbursedDate = date;
            r1.Status = Status.RetrievalStatus.created;
            Retrieval newRetrieval = retrivrepo.GenRetrievalAndReturn(r1); //creates empty retrieval form and returns it
            foreach (Requisition re in listreq)//listreq is passed in from controller, which is a list of requisition with "confirmed" status, on the selected date and processed by the clerk in session
            {
                if (rdlnew.Count != 0) //if there are new items in additional to earlier retrieved form to be followed up, trigger this block
                {
                    foreach (RequisitionDetail detail in rdlnew)
                    {
                        detail.RetrievalId = newRetrieval.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
                        RequisitionDetail x = rdrepo.UpdateRetrievalId(detail); //and update the requisition details, then return it back                    
                    }
                }
                else //at this stage if there are no new items when compared to earlier retrieved form, it means entire listreq is new. proceed to persist all
                {
                    foreach (RequisitionDetail detail in re.RequisitionDetails)
                    {
                        detail.RetrievalId = newRetrieval.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
                        RequisitionDetail x = rdrepo.UpdateRetrievalId(detail); //and update the requisition details, then return it back                    
                    }
                }
            }
            Retrieval updatedRetrieval2 = retrivrepo.GetRetrievalById(newRetrieval.Id); //Get back the latest created retrieval with all the related objects
            updatedRetrieval2.RequisitionDetails = updatedRetrieval2.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
            return updatedRetrieval2;
        }
        public bool UpdateRetrieval(Retrieval r1)
        {
            try
            {
                foreach (RequisitionDetail rd in r1.RequisitionDetails) //Check for sufficient balance in stock
                {
                    RequisitionDetail i = rdrepo.GetRequisitionDetailById(rd.Id);
                    Transaction t = trepo.GetLatestTransactionByProductId(i.ProductId);
                    if (rd.QtyDisbursed > t.Balance)
                    {
                        throw new Exception("Unable to update retrieval due to insufficient stocks");
                    }
                }
                /* if there is insufficient stocks based on transactions, error will be thrown, bottom code will not execute, retrieval form will not be updated */
                DateTime dateTime = DateTime.UtcNow.Date;
                DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
                r1.RetrievedDate = dt.ToUnixTimeMilliseconds();
                retrivrepo.UpdateRetrieval(r1);
                foreach (RequisitionDetail rd in r1.RequisitionDetails)
                {
                    rdrepo.UpdateRequsitionDetail(rd);
                    if (r1.Status == Status.RetrievalStatus.retrieved)
                    {
                        UpdateStockCardUponFinaliseRetrieval(rd, r1);
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public bool UpdateStockCardUponFinaliseRetrieval(RequisitionDetail rd, Retrieval r)
        {
            Retrieval retrieval = retrivrepo.GetRetrievalById(r.Id);
            RequisitionDetail rd1 = rdrepo.GetRequisitionDetailById(rd.Id);
            Transaction t_new = new Transaction();
            t_new.ProductId = rd.ProductId;
            t_new.Date = (long)retrieval.RetrievedDate;
            StringBuilder builder = new StringBuilder();
            t_new.Description = builder.Append("Disbursement to ").Append(retrieval.RequisitionDetails[0].Requisition.Department.Name).ToString();
            t_new.Qty = (int)rd.QtyDisbursed * -1;
            Transaction t_old = trepo.GetLatestTransactionByProductId(rd1.ProductId);
            t_new.ProductId = rd1.ProductId;
            t_new.Balance = t_old.Balance + t_new.Qty;
            t_new.UpdatedByEmpId = retrieval.ClerkId;
            t_new.RefCode = "Retrieval ID: " + retrieval.Id.ToString();
            trepo.SaveNewTransaction(t_new);
            return true;
        }
        public List<TenderQuotation> GetTop3Suppliers(string productId)
        {
            return tqrepo.GetTop3Suppliers(productId);
        }
        public List<RequisitionDetail> RetrieveDisbursementList(string deptId, long collectiondate)
        {
            return rdrepo.RetrieveDisbursementList(deptId, collectiondate);
        }
        public bool SaveTransaction(Transaction t1)
        {
            return trepo.SaveNewTransaction(t1);
        }
        public List<PurchaseRequestDetail> AddPurchaseRequest(List<string> productid, int clerkId)
        {
            long currentpurchaserequestid = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 42;

            foreach (string id in productid)
            {
                PurchaseRequestDetail prd1 = new PurchaseRequestDetail();
                prd1.ProductId = id;
                prd1.Status = Status.PurchaseRequestStatus.created;
                prd1.PurchaseRequestId = currentpurchaserequestid;
                Transaction t = trepo.GetLatestTransactionByProductId(id);
                prd1.CurrentStock = t.Balance;
                prd1.CreatedByClerkId = clerkId;
                purreqrepo.AddNewPurchaseRequestDetail(prd1);
            }
            List<PurchaseRequestDetail> prlist = purreqrepo.GetCurrentPurchaseRequest(currentpurchaserequestid);

            return prlist;
        }
        public bool UpdatePurchaseRequestItem(List<PurchaseRequestDetail> prdlist)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long date = dt.ToUnixTimeMilliseconds();
            List<PurchaseRequestDetail> updatedprlist = new List<PurchaseRequestDetail>();
            foreach (PurchaseRequestDetail prd in prdlist)
            {
                prd.SubmitDate = date;
                PurchaseRequestDetail pr = purreqrepo.UpdatePurchaseRequestItem(prd);
                updatedprlist.Add(pr);
            }
            string prdstatus = prdlist[0].Status;

            if (prdstatus == Status.PurchaseRequestStatus.pendapprov)
            {
                Employee supervisor = erepo.FindEmpById((int)updatedprlist[0].CreatedByClerk.ManagerId);
                EmailModel email = new EmailModel();
                Task.Run(async () =>
                {
                    EmailTemplates.UpdatePRStatusTemplate ctt = new EmailTemplates.UpdatePRStatusTemplate(updatedprlist, supervisor);
                    email.emailTo = supervisor.Email;
                    email.emailSubject = ctt.subject;
                    email.emailBody = ctt.body;
                    await mailservice.SendEmailAsync(email);
                });
            }
            return true;
        }
        public bool UpdatePurchaseOrderDetailItem(List<PurchaseOrderDetail> podlist)
        {
            try
            {
                foreach (PurchaseOrderDetail i in podlist) //updates all purchase order detail status
                {
                    podrepo.UpdatePurchaseOrderDetail(i);
                }
                PurchaseOrder po = porepo.FindPOByPOid((int)podlist[0].PurchaseOrderId); //retrieving back the parent PO of the purchaseorderdetail
                int receivedcounter = 0;
                foreach (PurchaseOrderDetail j in po.PurchaseOrderDetails) //checking status of every purchaseorderdetail in the PO. if status is received, counter++
                {
                    if (j.Status == Status.PurchaseOrderDetailStatus.received)
                    {
                        receivedcounter++;
                    }
                }
                if (receivedcounter == po.PurchaseOrderDetails.Count()) //if counter of received matches total purchaseorderdetail, means all items received. update PO status to completed
                {
                    po.Status = Status.PurchaseOrderStatus.completed;
                    porepo.UpdatePoStatus(po);
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public AdjustmentVoucher CreateAdjustmentVoucher(int clerkid)
        {
            //create empty adjustment voucher with only ID and initiated date
            AdjustmentVoucher av = new AdjustmentVoucher();

            av.InitiatedDate = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            av.Id = avrepo.CreateNewId();
            av.Status = Status.AdjVoucherStatus.created;
            av.InitiatedClerkId = clerkid;
            return avrepo.SaveNewAdjustmentVoucher(av);
        }
        public bool UpdateRequisitionCollectionTime(Requisition r1)
        {
            try
            {
                Requisition original = rrepo.UpdateRequisitionCollectionTime(r1);
                Employee drep = erepo.FindEmpById((int)original.Department.RepId);
                Employee deptemp = erepo.FindEmpById(original.ReqByEmpId);
                EmailModel email = new EmailModel();

                Task.Run(async () =>
                {
                    EmailTemplates.CollectionTimeTemplate ctt = new EmailTemplates.CollectionTimeTemplate(original, drep);
                    email.emailTo = drep.Email;
                    email.emailSubject = ctt.subject;
                    email.emailBody = ctt.body;
                    await mailservice.SendEmailwithccAsync(email, deptemp);
                });
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher()
        {
            return avrepo.FindAllAdjustmentVoucher();

        }
        public List<AdjustmentVoucherDetail> GetAdvDetailsByAdvId(string advId)
        {
            try
            {
                List<AdjustmentVoucherDetail> advdetails = avdetrepo.FindAdvDetailsbyAdvId(advId);

                return advdetails;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<Department> GetAllDepartment()
        {
            return drepo.FindAllDepartment();
        }
        public bool AckCompletedRequisition(List<RequisitionDetail> rdl, int clerkId)
        {
            try
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
                long date = dt.ToUnixTimeMilliseconds();
                foreach (RequisitionDetail rd in rdl)
                {
                    rdrepo.ClerkSaveRequisitionDetailRemarksOnCompletion(rd);
                    rrepo.ClerkCompleteRequisition(clerkId, (int)rd.RequisitionId, date, Status.RequsitionStatus.completed);
                }

                var uniquereqid = rdl.Select(m => m.RequisitionId).Distinct().ToList();
                List<Requisition> reqlist = new List<Requisition>();
                foreach (var i in uniquereqid)
                {
                    Requisition r = rrepo.FindReqByReqId((int)i);
                    reqlist.Add(r);
                }
                Employee drep = reqlist[0].ReceivedByRep;
                EmailModel email = new EmailModel();
                Task.Run(async () =>
                {
                    EmailTemplates.AckCompletedReq ctt = new EmailTemplates.AckCompletedReq(reqlist, drep);
                    email.emailTo = drep.Email;
                    email.emailSubject = ctt.subject;
                    email.emailBody = ctt.body;
                    await mailservice.SendEmailAsync(email);
                });


                return true;
            }
            catch (Exception m)
            {
                throw m;
            }
        }
        public bool UpdateAdjustmentVoucherDeatails(List<AdjustmentVoucherDetail> voucherDetails)
        {
            string AdjustmentVoucherId = voucherDetails[0].AdjustmentVoucherId;
            List<AdjustmentVoucherDetail> avd = avdetrepo.FindAdvDetailsbyAdvId(AdjustmentVoucherId);
            foreach (AdjustmentVoucherDetail av in avd)
            {
                avdetrepo.DeleteAdvDetails(av);
            }
            foreach (AdjustmentVoucherDetail j in voucherDetails)
            {
                j.AdjustmentVoucherId = AdjustmentVoucherId;
                avdetrepo.AddAdvDetail(j);
            }
            return true;
        }
        public bool ClerkSubmitAdjustmentVoucher(string adjustmentVoucherId)
        {
            AdjustmentVoucher av = avrepo.ClerkSubmitAdjustmentVoucher(adjustmentVoucherId);
            // sending email to store supervisor
            Employee clerk = av.InitiatedClerk;
            Employee sup = erepo.FindEmpById((int)clerk.ManagerId);
            EmailModel email = new EmailModel();
            Task.Run(async () =>
            {
                EmailTemplates.SubmitAV sav = new EmailTemplates.SubmitAV(sup, clerk);
                email.emailTo = sup.Email;
                email.emailSubject = sav.subject;
                email.emailBody = sav.body;
                await mailservice.SendEmailAsync(email);
            });
            return true;
        }
        public AdjustmentVoucher FindAdjustmentVoucherById(string advId)
        {
            return avrepo.FindAdjustmentVoucherById(advId);
        }
        public List<AdjustmentVoucher> FindAdjustmentVoucherByClerkId(int clerkid)
        {
            return avrepo.FindAdjustmentVoucherByClerkId(clerkid);
        }

        public TenderQuotation GetFirstTenderbyProdutId(string ProductId)
        {
            return tqrepo.GetFirstTenderbyProdutId(ProductId);
        }
        public List<Retrieval> GetRetrievalFormCommentsForAdjustmentVoucher()
        {
            long currentdate = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            List<Retrieval> rlistwithcomments = retrivrepo.GetRetrievalThatNeedAdjustmentVoucher(currentdate);
            return rlistwithcomments;
        }
        public List<Requisition> GetAllDisbursement()
        {
            List<Requisition> disbursementlist = rrepo.FindAllDisbursement();
            return disbursementlist;
        }
        public List<Retrieval> GetAllRetrievals()
        {
            List<Retrieval> retrievals = retrivrepo.GetAllRetrievals();
            return retrievals;
        }
        public Retrieval GetRetrievalById(int rId)
        {
            return retrivrepo.GetRetrievalById(rId);
        }
        public bool DeleteCreatedPurchaseRequest(long preqId)
        {
            List<PurchaseRequestDetail> prdlist = purreqrepo.FindPurchaseReq(preqId);
            foreach (PurchaseRequestDetail i in prdlist)
            {
                purreqrepo.DeleteCreatedPurchaseRequest(i);
            }
            return true;
        }
        public bool DeleteCreatedAdjustmentVoucher(string avId)
        {
            AdjustmentVoucher av = avrepo.FindAdjustmentVoucherById(avId);
            List<AdjustmentVoucherDetail> avl = avdetrepo.FindAdvDetailsbyAdvId(av.Id);
            foreach (AdjustmentVoucherDetail v in avl)
            {
                avdetrepo.DeleteAdvDetails(v);
            }
            avrepo.DeleteAdjustmentVoucher(av);
            return true;
        }
        public bool EmptyCreatedAdjustmentVoucher(string avId)
        {
            AdjustmentVoucher av = avrepo.FindAdjustmentVoucherById(avId);
            List<AdjustmentVoucherDetail> avl = avdetrepo.FindAdvDetailsbyAdvId(av.Id);
            foreach (AdjustmentVoucherDetail v in avl)
            {
                avdetrepo.DeleteAdvDetails(v);
            }
            return true;
        }
    }
}

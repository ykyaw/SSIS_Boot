using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.Common;
using SSIS_BOOT.Email;
using SSIS_BOOT.Email.EmailTemplates;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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

        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }
        public List<Transaction> getlatesttransaction(List<Product> pdt)
        {
            List<Transaction> tlist = new List<Transaction>();
            foreach(Product p in pdt)
            {
                Transaction t = trepo.GetLatestTransactionByProductId(p.Id);
                if(t== null)
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


        public List<PurchaseOrderDetail> getpoddetails(int poId)
        {
            return podrepo.findpodetails(poId);
        }

        public List<PurchaseOrder> getpurchaseorders()
        {
            return porepo.findallpurchaseorder();
        }

        public List<PurchaseRequestDetail> getpurchasereq()
        {
            return purreqrepo.findallpurchasereq();
        }


        public Requisition getReqByReqId(int reqid)
        {
            return rrepo.findreqformByReqID(reqid);
        }


        public List<PurchaseRequestDetail> getprdetails(long prid)
        {
            return purreqrepo.findpurchasereq(prid);
        }

        //to run this mtd as async
        public bool generatequotefrompr(List<PurchaseRequestDetail> prdlist,int clerkid)
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
                //List<PurchaseRequestDetail> pnull = prdlistwithnull.GroupBy(m => m.SupplierId).SelectMany(m => m).ToList(); 
                List<PurchaseRequestDetail> pnull = prdlistwithnull.OrderBy(m => m.SupplierId).ToList(); //IMPROVED      
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
                        //List<PurchaseRequestDetail> prdlist2 = pdict[prd.SupplierId];
                        pdict[prd.SupplierId].Add(prd);
                        //pdict[prd.SupplierId] = prdlist2;
                    }
                }
                foreach (var r in pdict)
                {
                    Supplier supplier = srepo.findsupplierbyId(r.Value[0].SupplierId);
                    Employee clerk = erepo.findempById(clerkid);
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

        public List<Requisition> getallreqform()
        {
            List<Requisition> lr = rrepo.findallreqform();
            List<Requisition> lr2 = new List<Requisition>();

            foreach(Requisition r in lr) //clerk should only be able to see all those requisitio after approved status
            {
                if (r.Status == Status.RequsitionStatus.approved || r.Status == Status.RequsitionStatus.confirmed || r.Status == Status.RequsitionStatus.received|| r.Status == Status.RequsitionStatus.completed)
                {
                    lr2.Add(r);
                }
            }
            return lr2;
        }

        public List<Requisition> getallreqformbydateandstatus(long date, int clerkid, string reqStatus)
        {
            return rrepo.findrequsitionbycollectiondateandstatus(date, clerkid, reqStatus);
        }

        public List<Requisition> getReqformByDeptId(string deptID)
        {
            List<Requisition> lr = rrepo.findreqformByDeptID(deptID);
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

        public List<Transaction> retrievestockcard(string productId)
        {
            return trepo.retrievestockcard(productId);
        }


        //public Retrieval genretrievalform(long date, int clerkid, List<Requisition> listreq) //ORIGINAL LOGIC
        //{
        //    Retrieval r_exist = retrivrepo.GetRetrieval(date, clerkid, Status.RetrievalStatus.created); // check if there already exist a retrieval with "created" status and processed by clerkid
        //    if (r_exist != null)
        //    {
        //        //delete old requisitiondetail
        //        //add new requisition detail

        //        return r_exist;
        //    }
        //    Retrieval r1 = new Retrieval();
        //    r1.ClerkId = clerkid;
        //    r1.DisbursedDate = date;
        //    r1.Status = Status.RetrievalStatus.created;
        //    Retrieval newRetrieval = retrivrepo.genretrievalandreturn(r1); //creates empty retrieval form and returns it

        //    foreach (Requisition re in listreq)//listreq is passed in from controller, which is a list of requisition with "confirmed" status, on the selected date and processed by the clerk in session
        //    {
        //        foreach (RequisitionDetail detail in re.RequisitionDetails)
        //        {
        //            detail.RetrievalId = newRetrieval.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
        //            RequisitionDetail x = rdrepo.updateretrievalid(detail); //and update the requisition details, then return it back                    
        //        }
        //    }
        //    Retrieval updatedRetrieval = retrivrepo.GetRetrievalById(newRetrieval.Id); //Get back the latest created retrieval with all the related objects
        //    updatedRetrieval.RequisitionDetails = updatedRetrieval.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
        //    return updatedRetrieval;
        //}



        public Retrieval genretrievalform(long date, int clerkid, List<Requisition> listreq) //UPDATED LOGIC
        {
            Retrieval r_exist = retrivrepo.GetRetrieval(date, clerkid, Status.RetrievalStatus.created); // check if there already exist a retrieval with "created" status and processed by clerkid

            if (r_exist != null) //If an existing retrieval form for the collection date has been created, update existing requisition with same date with the existing retrievalformId 
            {
                foreach (Requisition re in listreq)//listreq is passed in from controller, which is a list of requisition with "confirmed" status, on the selected date and processed by the clerk in session
                {
                    foreach (RequisitionDetail detail in re.RequisitionDetails)
                    {
                        detail.RetrievalId = r_exist.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
                        RequisitionDetail x = rdrepo.updateretrievalid(detail); //and update the requisition details, then return it back                    
                    }
                }
                Retrieval updatedRetrieval = retrivrepo.GetRetrievalById(r_exist.Id); //Get back the latest created retrieval with all the related objects
                updatedRetrieval.RequisitionDetails = updatedRetrieval.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
                return updatedRetrieval;
            }

            else //If there is no retrieval form for the collection date, create a new retrieval form and update existing requisition with same date with the newly created retrievalformId 
            {
                Retrieval r1 = new Retrieval();
                r1.ClerkId = clerkid;
                r1.DisbursedDate = date;
                r1.Status = Status.RetrievalStatus.created;
                Retrieval newRetrieval = retrivrepo.genretrievalandreturn(r1); //creates empty retrieval form and returns it

                foreach (Requisition re in listreq)//listreq is passed in from controller, which is a list of requisition with "confirmed" status, on the selected date and processed by the clerk in session
                {
                    foreach (RequisitionDetail detail in re.RequisitionDetails)
                    {
                        detail.RetrievalId = newRetrieval.Id; //assign the newly created retrieval Id to each requsitiondetail belonging to a confirmed retrieval 
                        RequisitionDetail x = rdrepo.updateretrievalid(detail); //and update the requisition details, then return it back                    
                    }
                }
                Retrieval updatedRetrieval = retrivrepo.GetRetrievalById(newRetrieval.Id); //Get back the latest created retrieval with all the related objects
                updatedRetrieval.RequisitionDetails = updatedRetrieval.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
                return updatedRetrieval;
            }
        }

        public bool updateretrieval(Retrieval r1)
        {
            try
            {
                foreach (RequisitionDetail rd in r1.RequisitionDetails) //Check for sufficient balance in stock
                {
                    RequisitionDetail i = rdrepo.GetRequisitionDetailById(rd.Id);
                    Transaction t = trepo.GetLatestTransactionByProductId(i.ProductId);
                    if(rd.QtyDisbursed > t.Balance)
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
                    rdrepo.updaterequsitiondetail(rd);
                    if(r1.Status == Status.RetrievalStatus.retrieved)
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
            Transaction t_new = new Transaction();
            t_new.ProductId = rd.ProductId;
            t_new.Date = (long)retrieval.RetrievedDate;

            StringBuilder builder = new StringBuilder();
            t_new.Description = builder.Append("Disbursement to ").Append(retrieval.RequisitionDetails[0].Requisition.Department.Name).ToString();

            t_new.Qty = (int)rd.QtyDisbursed;

            Transaction t_old = trepo.GetLatestTransactionByProductId(rd.ProductId);
            t_new.Balance = t_old.Balance - t_new.Qty;

            t_new.UpdatedByEmpId = retrieval.ClerkId;
            t_new.RefCode = retrieval.Id.ToString();

            trepo.savenewtransaction(t_new);
            return true;
        }

        public List<TenderQuotation> gettop3suppliers(string productId)
        {
            return tqrepo.gettop3suppliers(productId);
        }

        public List<RequisitionDetail> retrievedisbursementlist(string deptId, long collectiondate)
        {
            return rdrepo.retrievedisbursementlist(deptId, collectiondate);
        }

        public bool savetransaction(Transaction t1)
        {
            return trepo.savenewtransaction(t1);
        }

        public List<PurchaseRequestDetail> addpurchaserequest(List<string> productid, int clerkId)
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
                //prd1.CreatedByClerkId = (int)2;
                prd1.CreatedByClerkId = clerkId;
                purreqrepo.addnewpurchaserequestdetail(prd1);
            }
            List<PurchaseRequestDetail> prlist = purreqrepo.getcurrentpurchaserequest(currentpurchaserequestid);

            return prlist;
        }

        public bool updatepurchaserequestitem(List<PurchaseRequestDetail> prdlist)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
            long date = dt.ToUnixTimeMilliseconds();
            List<PurchaseRequestDetail> updatedprlist = new List<PurchaseRequestDetail>();
            foreach (PurchaseRequestDetail prd in prdlist)
            {
                prd.SubmitDate = date;
                PurchaseRequestDetail pr = purreqrepo.updatepurchaserequestitem(prd);
                updatedprlist.Add(pr);
            }
            string prdstatus = prdlist[0].Status;

            if (prdstatus == Status.PurchaseRequestStatus.pendapprov)
            {
                Employee supervisor = erepo.findempById((int)updatedprlist[0].CreatedByClerk.ManagerId);
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


        public bool updatepurchaseorderdetailitem(PurchaseOrderDetail pod)
        {
            try
            {
                podrepo.Updatepurchaseorderdetail(pod);
                PurchaseOrder po = porepo.findPObyPOid((int)pod.PurchaseOrderId);
                foreach(PurchaseOrderDetail pod1 in po.PurchaseOrderDetails)
                {
                    //Checks for anymore pending status in PurchaseOrderDetail. If yes, PO status is saved as pending and break the loop
                    if (pod1.Status == Status.PurchaseOrderDetailStatus.pending) 
                    {
                        po.Status = Status.PurchaseOrderStatus.pending;
                        porepo.updatePoStatus(po);
                        return true;
                    }
                    po.Status = Status.PurchaseOrderStatus.completed; //If all PurchaseOrderDetal has status of received, if statement is not triggered. PO status is saved as completed
                    porepo.updatePoStatus(po);
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public AdjustmentVoucher createadjustmentvoucher(int clerkid)
        {
            //create empty adjustment voucher with only ID and initiated date
            AdjustmentVoucher av = new AdjustmentVoucher();

            av.InitiatedDate = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            av.Id = avrepo.createnewid();
            av.Status = Status.AdjVoucherStatus.created;
            av.InitiatedClerkId = clerkid;

            return avrepo.saveNewAdjustmentVoucher(av);
        }


        public bool updaterequisitioncollectiontime(Requisition r1)
        {
            try
            {
                Requisition original = rrepo.updaterequisitioncollectiontime(r1);

                Employee drep = erepo.findempById((int)original.Department.RepId);
                Employee deptemp = erepo.findempById(original.ReqByEmpId);
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
        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            return avrepo.findAllAdjustmentVoucher();

        }

        public List<AdjustmentVoucherDetail> getAdvDetailsbyAdvId(string advId)
        {
            try
            {
                List<AdjustmentVoucherDetail> advdetails = avdetrepo.findAdvDetailsbyAdvId(advId);

                return advdetails;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<Department> getalldepartment()
        {
            return drepo.findalldepartment();
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
                    rrepo.ClerkCompleteRequisition(clerkId, (int)rd.RequisitionId, date, Status.RequsitionStatus.received);
                }

                var uniquereqid = rdl.Select(m => m.RequisitionId).Distinct().ToList();
                List<Requisition> reqlist = new List<Requisition>();
                foreach (var i in uniquereqid)
                {
                    Requisition r = rrepo.findreqByReqId((int)i);
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
        public void deleteOriginalDetails(string AdjustmentVoucherId)
        {

            avdetrepo.deleteAdvDetailsbyAdvId(AdjustmentVoucherId);

        }

        public bool updateAdjustmentVoucherDeatails(List<AdjustmentVoucherDetail> voucherDetails)
        {
            string AdjustmentVoucherId = voucherDetails[0].AdjustmentVoucherId;
            //if there are details in this adjustment voucher
            if (avdetrepo.hasDetails(AdjustmentVoucherId))
            {
                avdetrepo.deleteAdvDetailsbyAdvId(AdjustmentVoucherId);
            }
            foreach (AdjustmentVoucherDetail avdetail in voucherDetails)
            {
                avdetrepo.updateAdjustmentVoucherDeatail(avdetail);
            }
            avrepo.ClerkUpdateAdjustmentVoucherById(AdjustmentVoucherId);
            return true;

        }

        public bool ClerkSubmitAdjustmentVoucher(string adjustmentVoucherId)
        {
            AdjustmentVoucher av = avrepo.ClerkSubmitAdjustmentVoucher(adjustmentVoucherId);
            // sending email to store supervisor
            Employee clerk = av.InitiatedClerk;
            Employee sup = av.InitiatedClerk.Manager;
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

        public AdjustmentVoucher findAdjustmentVoucherById(string advId)
        {
            return avrepo.findAdjustmentVoucherById(advId);
        }

        public List<AdjustmentVoucher> findAdjustmentVoucherByClerkId(int clerkid)
        {
            return avrepo.findAdjustmentVoucherByClerkId(clerkid);
        }

        public TenderQuotation getFirstTenderbyProdutId(string ProductId)
        {
            return tqrepo.getFirstTenderbyProdutId(ProductId);
        }


    }
}

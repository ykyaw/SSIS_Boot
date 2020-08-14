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
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class StoreClerkServiceImpl : IStoreClerkService
    {
        public ProductRepo prepo;
        public PurchaseRequestRepo purreqrepo;
        public PurchaseOrderRepo porepo;
        public PurchaseOrderDetailRepo podrepo;
        public RequisitionRepo rrepo;
        public RequisitionDetailRepo rdrepo;
        public TransactionRepo trepo;
        public RetrievalRepo retrivrepo;
        public TenderQuotationRepo tqrepo;
        public EmployeeRepo erepo;
        public SupplierRepo srepo;
        protected IMailer mailservice;
        public AdjustmentVoucherRepo avrepo;
        public DepartmentRepo drepo;
        public AdjustmentVoucherDetailRepo avdetrepo;


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
        public bool generatequotefrompr(List<PurchaseRequestDetail> prdlist)
        {
            List<PurchaseRequestDetail> prdlistwithnull = new List<PurchaseRequestDetail>();

            foreach (PurchaseRequestDetail prd in prdlist)
            {
                if (prd.VenderQuote == null)
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
                List<PurchaseRequestDetail> pnull = prdlistwithnull.GroupBy(m => m.SupplierId).SelectMany(m => m).ToList();
                Dictionary<string, List<PurchaseRequestDetail>> pdict = new Dictionary<string, List<PurchaseRequestDetail>>();

                foreach (PurchaseRequestDetail prd in pnull)
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
                foreach (var r in pdict)
                {
                    Supplier supplier = srepo.findsupplierbyId(r.Value[0].SupplierId);
                    Employee clerk = erepo.findempById(r.Value[0].CreatedByClerkId);
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
            return rrepo.findallreqform();
        }

        public List<Requisition> getallreqformbydate(long date)
        {
            return rrepo.findrequsitionbycollectiondate(date);
        }

        public List<Requisition> getReqformByDeptId(string deptID)
        {
            return rrepo.findreqformByDeptID(deptID);
        }

        public List<Transaction> retrievestockcard(string productId)
        {
            return trepo.retrievestockcard(productId);
        }


        public Retrieval genretrievalform(long date, int clerkid)
        {
            Retrieval r_exist = retrivrepo.GetRetrieval(date);
            if (r_exist != null)
            {
                return r_exist;
            }
            Retrieval r1 = new Retrieval();
            r1.ClerkId = clerkid;
            r1.DisbursedDate = date;
            r1.Status = Status.RetrievalStatus.created;
            Retrieval r2 = retrivrepo.genretrievalandreturn(r1); //creates retrieval form and returns it
            List<Requisition> req1 = rrepo.findrequsitionbycollectiondate(date);
            foreach (Requisition re in req1)
            {
                foreach (RequisitionDetail detail in re.RequisitionDetails)
                {
                    detail.RetrievalId = r2.Id; //assign the newly created retrieval Id to each requsitiondetail 
                    RequisitionDetail x = rdrepo.updateretrievalid(detail); //and update the requisition details, then return it back                    
                }
            }
            Retrieval r3 = retrivrepo.GetRetrieval(date);
            r3.RequisitionDetails = r3.RequisitionDetails.GroupBy(m => m.Product.Description).SelectMany(r => r).ToList();
            return r3;
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

        public List<PurchaseRequestDetail> addpurchaserequest(List<String> productid, int clerkId)
        {
            long currentpurchaserequestid = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 42;

            foreach (String id in productid)
            {
                PurchaseRequestDetail prd1 = new PurchaseRequestDetail();
                prd1.ProductId = id;
                prd1.Status = Status.PurchaseRequestStatus.created;
                prd1.PurchaseRequestId = currentpurchaserequestid;
                //prd1.CreatedByClerkId = (int)2;
                prd1.CreatedByClerkId = clerkId;
                purreqrepo.addnewpurchaserequestdetail(prd1);
            }
            List<PurchaseRequestDetail> prlist = purreqrepo.getcurrentpurchaserequest(currentpurchaserequestid);

            return prlist;
        }

        public bool updatepurchaserequestitem(List<PurchaseRequestDetail> prdlist)
        {
            foreach (PurchaseRequestDetail prd in prdlist)
            {
                purreqrepo.updatepurchaserequestitem(prd);
            }

            //retrieve the current status of prd
            IEnumerable<string> status = from prd in prdlist
                                         select prd.Status;
            string prdstatus = status.First();

            if (prdstatus == Status.PurchaseRequestStatus.pendapprov)
            {
                IEnumerable<int> clerkid = from prd in prdlist
                                           select prd.CreatedByClerkId;
                int clerkId = clerkid.First();

                Employee supervisor = erepo.findSupervisorByEmpId(clerkId);
                //send email to supervisor(PENDING)
                // if (supervisor !=null){}

            }
            return true;
        }

        public bool updateretrieval(Retrieval r1)
        {
            try
            {
                retrivrepo.UpdateRetrieval(r1);
                foreach (RequisitionDetail rd in r1.RequisitionDetails)
                {
                    rdrepo.updaterequsitiondetail(rd);
                }
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public bool updatepurchaseorderdetailitem(PurchaseOrderDetail pod)
        {
            try
            {
                podrepo.Updatepurchaseorderdetail(pod);
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
                rrepo.updaterequisitioncollectiontime(r1);


                //IMPLEMENT EMAIL SERVICE TO INFORM REP OF COLLECTION TIME

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
    }
}

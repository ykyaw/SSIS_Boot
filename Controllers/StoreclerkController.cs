using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class StoreclerkController : Controller
    {
        private IStoreClerkService scservice;

        public StoreclerkController(IStoreClerkService scservice)
        {
            this.scservice = scservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]        
        [Route("/storeclerk/catalogue")]
        public List<Product> getcatalogue()
        {
            List<Product> pdt = scservice.getallcat();
            return pdt;
        }
        [HttpGet]
        [Route("/storeclerk/glt")]
        public List<Transaction> getlatesttransaction()
        {
            List<Product> pdt = scservice.getallcat();
            List<Transaction> latesttrans = scservice.getlatesttransaction(pdt);
            List<Transaction> sortedlatesttrans = latesttrans.OrderBy(m => m.ProductId).ToList();
            return sortedlatesttrans;
        }


        [HttpGet]
        [Route("/storeclerk/pr")]
        public List<PurchaseRequestDetail> getallpurchasereq()
        {
            List<PurchaseRequestDetail> prdetails = scservice.getpurchasereq();
            return prdetails;
        }
        [HttpGet]
        [Route("/storeclerk/prdetails/{prid}")]
        public List<PurchaseRequestDetail> getprdetails(long prid)
        {
            List<PurchaseRequestDetail> prdetails = scservice.getprdetails(prid);
            return prdetails;
        }

        [HttpGet]
        [Route("/storeclerk/po")]
        public List<PurchaseOrder> getallpurchaseorder()
        {
            List<PurchaseOrder> prorderlist = scservice.getpurchaseorders();
            return prorderlist;
        }
        [HttpGet]
        [Route("/storeclerk/pod/{poId}")]
        public List<PurchaseOrderDetail> getpodetails(int poId)
        {
            List<PurchaseOrderDetail> podlist = scservice.getpoddetails(poId);
            return podlist;
        }
        [HttpGet]
        [Route("/storeclerk/rf")]
        public List<Requisition> getallreqform()
        {
            List<Requisition> reqlist = scservice.getallreqform();
            //sort by date
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }
        [HttpGet]
        [Route("/storeclerk/rf/{deptID}")]
        public List<Requisition> getreqformByDeptId(string deptID)
        {
            List<Requisition> reqlist = scservice.getReqformByDeptId(deptID);
            //sort by date
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m=>m.CreatedDate).ToList();
            return sortedreqlist;
        }

        [HttpGet]
        [Route("/storeclerk/rfld2/{reqId}")]
        public Requisition getreqformByReqId(int reqId)
        {
            Requisition req = scservice.getReqByReqId(reqId);
            return req;
        }

        [HttpPut] //TO FOLLOW UP
        [Route("/storeclerk/rfld")]
        public bool updateRequisitionCollectionTime([FromBody] Requisition r1)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                r1.ProcessedByClerkId = clerkid;
                scservice.updaterequisitioncollectiontime(r1);
                ////To be followed up. Also include email service to rep
                return true;
            }
            catch 
            {
                throw new Exception("Error updating collection time. Please check entry again");
            }

        }

        [HttpGet]
        [Route("/storeclerk/sc/{productId}")]
        public List<Transaction> retrievestockcard(string productId)
        {
            List<Transaction> plist = scservice.retrievestockcard(productId);
            return plist;
        }

        [Route("/storeclerk/ret/{date}")]
        public Retrieval genretrievalform(long date)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<Requisition> listreq = scservice.getallreqformbydateandstatus(date, clerkid, Status.RequsitionStatus.confirmed); //retrieve requisition where status is confirmed 
            if (listreq == null || listreq.Count == 0)
            {
                throw new Exception("Sorry, you currently don't have any confirmed requisition on this provided date that requires retrieval");
            }
            Retrieval r1 = scservice.genretrievalform(date, clerkid, listreq);
            return r1;
        }

        [HttpGet]
        [Route("/storeclerk/retid/{rId}")]
        public Retrieval retrievalformdetail(int rId)
        {
            Retrieval r1 = scservice.GetRetrievalById(rId);
            return r1;
        }

        ////FOR TESTING ONLY
        //[HttpGet]
        //[Route("/storeclerk/ret")]
        //public Retrieval genretrievalform()
        //{
        //    //long date = 99; //check for invalid date
        //    long date = 1597060800000; // for creating of new
        //    //long date = 1595237400; // check for existing
        //    int clerkid = 1;
        //    List<Requisition> rq = scservice.getallreqformbydate(date);
        //    if (rq == null || rq.Count == 0)
        //    {
        //        throw new Exception("Sorry, there is no Requisition matching the provided date. Please try again");
        //    }
        //    Retrieval r1 = scservice.genretrievalform(date, clerkid);
        //    return r1;
        //}



        [HttpPut]
        [Route("/storeclerk/ret")]
        public bool updateretrieval([FromBody] Retrieval r1)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                Retrieval r = r1;
                r.ClerkId = clerkid;
                scservice.updateretrieval(r);
                return true;
            }
            catch (Exception m)
            {
                string msg = m.Message;
                throw new Exception(msg);
            }
        }

        [HttpGet]
        [Route("/storeclerk/supplier/{productId}")]
        public List<TenderQuotation> gettop3supplier(string productId)
        {
            List<TenderQuotation> slist = scservice.gettop3suppliers(productId);
            return slist;
        }
        [HttpPost]
        [Route("/storeclerk/disbursement")]
        public List<RequisitionDetail> retrievedisbursementlist([FromBody]Requisition r1)
        {
            string deptId = r1.DepartmentId;
            long collectiondate = (long)r1.CollectionDate;
            //string deptId = "CPSC";
            //long collectiondate = 1597060800;
            List<RequisitionDetail> dlist = scservice.retrievedisbursementlist(deptId, collectiondate);
            if (dlist == null || dlist.Count == 0)
            {
                throw new Exception("Sorry, there is no Disbursement matching the provided date for this department.");
            }
            return dlist;
        }



        [HttpGet]
        [Route("/storeclerk/alldis")]
        public List<Requisition> GetAllDisbursement()
        {
            List<Requisition> alldisbursement = scservice.GetAllDisbursement();
            return alldisbursement;
        }


        [HttpPost]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPOST] and pass in from body
        [Route("/storeclerk/updatesc")]
        public bool updatestockcard([FromBody] Transaction t1)
        {
            //for testing purpose 
            //Transaction t1 = new Transaction("C001", 1597211000, "supply to Math Department", -20, 530, 1, null); //August 12, 2020 13:43:20
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            t1.UpdatedByEmpId = clerkid;
            t1.Date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); //added by tk, to be able to track to the milisecond for date of transaction
            scservice.savetransaction(t1);
            return true;
        }
        [HttpPost]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPOST] and pass in from body
        [Route("/storeclerk/createpr")]
        public List<PurchaseRequestDetail> generatepurchaserequest([FromBody]List<string> productId)
        {
            //testing 
            //List<String> productId = new List<string> {"C004", "F021" };

            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<PurchaseRequestDetail> prlist = scservice.addpurchaserequest(productId, clerkid);
            return prlist;

        }
        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/storeclerk/updatepr")]
        public bool Updatepurchaserequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            //testing  
            //List<PurchaseRequestDetail> prdetails = scservice.getpurchasereq();
            //PurchaseRequestDetail prd1 = prdetails.Find(item => item.Id == 8);
            //prd1.ReorderQty = 5000;
            //prd1.VenderQuote = "QUO03";
            //prd1.SupplierId = "ALPA";
            //prd1.Status = Status.PurchaseRequestStatus.pendapprov;
            //PurchaseRequestDetail prd2 = prdetails.Find(item => item.Id == 9);
            //prd2.ReorderQty = 100;
            //prd2.VenderQuote = "QUO04";
            //prd2.SupplierId = "ALPA";
            //prd2.Status = Status.PurchaseRequestStatus.pendapprov;
            //List<PurchaseRequestDetail> prdlist = new List<PurchaseRequestDetail> { prd1, prd2 };
            //int clerkid = (int)HttpContext.Session.GetInt32("Id");
            scservice.updatepurchaserequestitem(prdlist);
            //List<PurchaseRequestDetail> prdetailsfinal = scservice.getpurchasereq();
            return true;
        }

        //[HttpGet] //For testing oly
        [HttpPost]
        [Route("/storeclerk/generatequote")]
        public bool generatequotefrompr([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            ////Testing with fake value
            //List<PurchaseRequestDetail> prd = new List<PurchaseRequestDetail>();
            //PurchaseRequestDetail p1 = new PurchaseRequestDetail(1593617400000, 1, "E032", "ALPA", 80, 100, null, 100.00, 1593617400000, 1593691200000, 2, "approved", null);
            //p1.Product = new Product("C001", "Clips Double 1", 4);
            //PurchaseRequestDetail p2 = new PurchaseRequestDetail(1593617400000, 1, "D001", "OMEG", 80, 100, null, 100.00, 1593617400000, 1593691200000, 2, "approved", null);
            //p2.Product = new Product("E032", "Exercise Book A4 Hardcover (100 pg)", 4);
            //PurchaseRequestDetail p3 = new PurchaseRequestDetail(1593617400000, 1, "C001", "ALPA", 80, 100, null, 100.00, 1593617400000, 1593691200000, 2, "approved", null);
            //p3.Product = new Product("F020", "File Separator", 4);
            //PurchaseRequestDetail p4 = new PurchaseRequestDetail(1593617400000, 1, "P043", "OMEG", 80, 100, null, 100.00, 1593617400000, 1593691200000, 2, "approved", null);
            //p4.Product = new Product("H011", "Highlighter Blue", 4);
            //prd.Add(p1);
            //prd.Add(p2);
            //prd.Add(p3);
            //prd.Add(p4);
            //prd.Add(new PurchaseRequestDetail(1593617400000, 1, "E032", "OMEG", 80, 100, "MF032", 100.00, 1593617400000, 1593691200000, 2, "approved", null));
            //prd.Add(new PurchaseRequestDetail(1593617400000, 1, "E032", "ALPA", 80, 100, "MFD001", 100.00, 1593617400000, 1593691200000, 2, "approved", null));
            //prd.Add(new PurchaseRequestDetail(1593617400000, 1, "E032", "OMEG", 80, 100, "MF032", 100.00, 1593617400000, 1593691200000, 2, "approved", null));
            //scservice.generatequotefrompr(prd);
            //// END OF TEST
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            scservice.generatequotefrompr(prdlist,clerkid);
            return true;
        }

        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/storeclerk/updatepod")]
        public bool updateitemreceived([FromBody]List<PurchaseOrderDetail> podlist)
        {
            //testing 
            //int poid = 3;
            //List<PurchaseOrderDetail> podlist1 = scservice.getpoddetails(poid);
            //PurchaseOrderDetail pod1 = podlist1.Find(item => item.Id == 2);
            //pod1.QtyReceived = 5;
            //pod1.SupplierDeliveryNo = 111111;
            //pod1.Remark = "Pending 10 more";
            //pod1.PurchaseOrder.ReceivedDate = 1594724400000;
            //List<PurchaseOrderDetail> podlist = new List<PurchaseOrderDetail> { pod1 };
            if(podlist ==null || podlist.Count == 0)
            {
                throw new Exception("Error in updating item received. Please ensure all fields are completed");
            }
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            foreach (PurchaseOrderDetail podid in podlist)
            {
                podid.ReceivedByClerkId = clerkid;
            }
            scservice.updatepurchaseorderdetailitem(podlist);
            return true;
        }

        [HttpGet]
        [Route("/storeclerk/createav")]
        public AdjustmentVoucher createadjustmentvoucher()
        {
            int clerkid= (int)HttpContext.Session.GetInt32("Id");
            AdjustmentVoucher av = scservice.createadjustmentvoucher(clerkid);
            return av;
        }

        [HttpGet]
        [Route("/storeclerk/adv")]
        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = scservice.getAllAdjustmentVoucher();
            return advlist;
        }
        [HttpGet]
        [Route("/storeclerk/retrievealldept")]
        public List<Department> retrievedepartment()
        {
            List<Department> deptlist = scservice.getalldepartment();
            return deptlist;
        }

        [HttpGet]
        [Route("/storeclerk/advdet/{advId}")]
        public List<AdjustmentVoucherDetail> getAdvDetailsbyAdvId(string advId)
        {
            List<AdjustmentVoucherDetail> advdetails = scservice.getAdvDetailsbyAdvId(advId);
            return advdetails;
        }

        [HttpPut]
        [Route("/storeclerk/ackreq")]
        public bool AckCompletedRequisition([FromBody] List<RequisitionDetail> rdl)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                scservice.AckCompletedRequisition(rdl, clerkid);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("/storeclerk/UpdateAdjustmentDetails/")]
        public bool UpdataeAdjustmentDetails([FromBody]List<AdjustmentVoucherDetail> voucherDetails)
        {

            //int clerkid = (int)HttpContext.Session.GetInt32("Id");
            return scservice.updateAdjustmentVoucherDeatails(voucherDetails);
        }

        [HttpPut]
        [Route("/storeclerk/SubmitAdjustmentDetails/")]
        public bool SubmitAdjustmentDetails([FromBody]List<AdjustmentVoucherDetail> voucherDetails)
        {
            //UpdataeAdjustmentDetails(voucherDetails); //Edited by TK. Controller can call service method directly, no need to call another controller to access the same service method
            scservice.updateAdjustmentVoucherDeatails(voucherDetails);
            string adjustmentVoucherId = voucherDetails[0].AdjustmentVoucherId;
            scservice.ClerkSubmitAdjustmentVoucher(adjustmentVoucherId);
            return true;
        }

        [HttpGet]
        [Route("/storeclerk/findAdjustmentVoucher/{advId}")]
        public AdjustmentVoucher findAdjustmentVoucherById(string advId)
        {
            AdjustmentVoucher av = scservice.findAdjustmentVoucherById(advId);
            return av;
        }

        [HttpGet]
        [Route("/storeclerk/findAdjustmentVoucherbyClerk/")]
        public List<AdjustmentVoucher> findAdjustmentVoucherByClerkId()
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            return scservice.findAdjustmentVoucherByClerkId(clerkid);
        }


        [HttpGet]
        [Route("/storeclerk/FirstTenderbyProdutId/{ProductId}")]
        public TenderQuotation getFirstTenderbyProdutId(string ProductId)
        {
           return scservice.getFirstTenderbyProdutId(ProductId);
        }

        [HttpGet]
        [Route("/storeclerk/retformav")]
        public List<Retrieval> GetRetrievalFormCommentsForAdjustmentVoucher()
        {
            List<Retrieval> retrievalwithcomments = scservice.GetRetrievalFormCommentsForAdjustmentVoucher();
            if(retrievalwithcomments != null || retrievalwithcomments.Count !=0)
            {
                return retrievalwithcomments;
            }
            else
            {
                return new List<Retrieval>(); //if no retrieval with adjustment voucher comments, return empty list so front end don't need to handle error
            }
        }

        [HttpGet]
        [Route("/storeclerk/allrf")]
        public List<Retrieval> GetAllRetrievalForms()
        {
            List<Retrieval> retrieval = scservice.GetAllRetrievals();
            //sort by date
            List<Retrieval> sortedretlist = retrieval.OrderByDescending(m => m.RetrievedDate).ToList();
            return sortedretlist;
        }

        //[HttpGet]
        //[Route("/storeclerk/stockbal")]
        //public Dictionary<string, int> GetLatestBalanceStock()
        //{
        //    Dictionary<string, int> lateststock = new Dictionary<string, int>();
        //    lateststock = scservice.GetLatestBalanceStock();
        //    return lateststock;
        //}


    }
}
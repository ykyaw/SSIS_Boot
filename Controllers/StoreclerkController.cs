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
            List<Transaction> plist2 = plist.OrderByDescending(m => m.Date).ThenByDescending(m=>m.Id).ToList();
            return plist2;
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
        [Route("/storeclerk/updatesc")]
        public bool updatestockcard([FromBody] Transaction t1)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            t1.UpdatedByEmpId = clerkid;
            t1.Date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); //added by tk, to be able to track to the milisecond for date of transaction
            scservice.savetransaction(t1);
            return true;
        }
        [HttpPost]
        [Route("/storeclerk/createpr")]
        public List<PurchaseRequestDetail> generatepurchaserequest([FromBody]List<string> productId)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<PurchaseRequestDetail> prlist = scservice.addpurchaserequest(productId, clerkid);
            return prlist;

        }
        [HttpPut]
        [Route("/storeclerk/updatepr")]
        public bool Updatepurchaserequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            scservice.updatepurchaserequestitem(prdlist);
            return true;
        }


        [HttpPost]
        [Route("/storeclerk/generatequote")]
        public bool generatequotefrompr([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            scservice.generatequotefrompr(prdlist,clerkid);
            return true;
        }

        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/storeclerk/updatepod")]
        public bool updateitemreceived([FromBody]List<PurchaseOrderDetail> podlist)
        {

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

        [HttpDelete]
        [Route("/storeclerk/dpreq/{preqId}")]
        public bool DeleteCreatedPurchaseRequest(long preqId)
        {
            scservice.DeleteCreatedPurchaseRequest(preqId);
            return true;
        }

        [HttpDelete]
        [Route("/storeclerk/dav/{avId}")]
        public bool DeleteCreatedAdjustmentVoucher(string avId)
        {
            scservice.DeleteCreatedAdjustmentVoucher(avId);
            return true;
        }


    }
}
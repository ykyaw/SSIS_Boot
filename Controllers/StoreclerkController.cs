using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim, Guo Xiujuan
 */
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
        public List<Product> GetCatalogue()
        {
            List<Product> pdt = scservice.GetAllCat();
            return pdt;
        }
        [HttpGet]
        [Route("/storeclerk/glt")]
        public List<Transaction> GetLatestTransaction()
        {
            List<Product> pdt = scservice.GetAllCat();
            List<Transaction> latesttrans = scservice.GetLatestTransaction(pdt);
            List<Transaction> sortedlatesttrans = latesttrans.OrderBy(m => m.ProductId).ToList();
            return sortedlatesttrans;
        }

        [HttpGet]
        [Route("/storeclerk/pr")]
        public List<PurchaseRequestDetail> GetAllPurchasereq()
        {
            List<PurchaseRequestDetail> prdetails = scservice.GetPurchaseReq();
            return prdetails;
        }
        [HttpGet]
        [Route("/storeclerk/prdetails/{prid}")]
        public List<PurchaseRequestDetail> GetPrDetails(long prid)
        {
            List<PurchaseRequestDetail> prdetails = scservice.GetPrDetails(prid);
            return prdetails;
        }

        [HttpGet]
        [Route("/storeclerk/po")]
        public List<PurchaseOrder> GetAllPurchaseOrder()
        {
            List<PurchaseOrder> prorderlist = scservice.GetPurchaseOrders();
            return prorderlist;
        }
        [HttpGet]
        [Route("/storeclerk/pod/{poId}")]
        public List<PurchaseOrderDetail> GetPoDetails(int poId)
        {
            List<PurchaseOrderDetail> podlist = scservice.GetPodDetails(poId);
            return podlist;
        }
        [HttpGet]
        [Route("/storeclerk/rf")]
        public List<Requisition> GetallReqform()
        {
            List<Requisition> reqlist = scservice.GetAllReqForm();
            //sort by date
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }
        [HttpGet]
        [Route("/storeclerk/rf/{deptID}")]
        public List<Requisition> GetReqFormByDeptId(string deptID)
        {
            List<Requisition> reqlist = scservice.GetReqFormByDeptId(deptID);
            //sort by date
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }

        [HttpGet]
        [Route("/storeclerk/rfld2/{reqId}")]
        public Requisition GetReqFormByReqId(int reqId)
        {
            Requisition req = scservice.GetReqByReqId(reqId);
            return req;
        }

        [HttpPut]
        [Route("/storeclerk/rfld")]
        public bool UpdateRequisitionCollectionTime([FromBody] Requisition r1)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                r1.ProcessedByClerkId = clerkid;
                scservice.UpdateRequisitionCollectionTime(r1);
                return true;
            }
            catch
            {
                throw new Exception("Error updating collection time. Please check entry again");
            }
        }

        [HttpGet]
        [Route("/storeclerk/sc/{productId}")]
        public List<Transaction> RetrieveStockcard(string productId)
        {
            List<Transaction> plist = scservice.RetrieveStockcard(productId);
            return plist;
        }

        [Route("/storeclerk/ret/{date}")]
        public Retrieval GenRetrievalForm(long date)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<Requisition> listreq = scservice.GetAllReqFormByDateAndStatus(date, clerkid, Status.RequsitionStatus.confirmed); //retrieve requisition where status is confirmed 
            if (listreq == null || listreq.Count == 0)
            {
                throw new Exception("Sorry, you currently don't have any confirmed requisition on this provided date that requires retrieval");
            }
            Retrieval r1 = scservice.GenRetrievalForm(date, clerkid, listreq);
            return r1;
        }

        [HttpGet]
        [Route("/storeclerk/retid/{rId}")]
        public Retrieval RetrievalFormDetail(int rId)
        {
            Retrieval r1 = scservice.GetRetrievalById(rId);
            return r1;
        }

        [HttpPut]
        [Route("/storeclerk/ret")]
        public bool UpdateRetrieval([FromBody] Retrieval r1)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                Retrieval r = r1;
                r.ClerkId = clerkid;
                scservice.UpdateRetrieval(r);
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
        public List<TenderQuotation> GetTop3supplier(string productId)
        {
            List<TenderQuotation> slist = scservice.GetTop3Suppliers(productId);
            return slist;
        }
        [HttpPost]
        [Route("/storeclerk/disbursement")]
        public List<RequisitionDetail> RetrieveDisbursementList([FromBody]Requisition r1)
        {
            string deptId = r1.DepartmentId;
            long collectiondate = (long)r1.CollectionDate;
            List<RequisitionDetail> dlist = scservice.RetrieveDisbursementList(deptId, collectiondate);
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
            List<Requisition> alldisbursementordered = alldisbursement.OrderByDescending(m => m.CollectionDate).ToList();
            return alldisbursementordered;
        }

        [HttpPost]
        [Route("/storeclerk/updatesc")]
        public bool UpdateStockcard([FromBody] Transaction t1)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            t1.UpdatedByEmpId = clerkid;
            t1.Date = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); 
            scservice.SaveTransaction(t1);
            return true;
        }
        [HttpPost]
        [Route("/storeclerk/createpr")]
        public List<PurchaseRequestDetail> GeneratePurchaseRequest([FromBody]List<string> productId)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<PurchaseRequestDetail> prlist = scservice.AddPurchaseRequest(productId, clerkid);
            return prlist;
        }

        [HttpPut]
        [Route("/storeclerk/updatepr")]
        public bool UpdatePurchaseRequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            scservice.UpdatePurchaseRequestItem(prdlist);
            return true;
        }

        [HttpPost]
        [Route("/storeclerk/generatequote")]
        public bool GenerateQuoteFrompr([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            scservice.GenerateQuoteFromPr(prdlist, clerkid);
            return true;
        }

        [HttpPut]
        [Route("/storeclerk/updatepod")]
        public bool UpdateItemReceived([FromBody]List<PurchaseOrderDetail> podlist)
        {

            if (podlist == null || podlist.Count == 0)
            {
                throw new Exception("Error in updating item received. Please ensure all fields are completed");
            }
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            foreach (PurchaseOrderDetail podid in podlist)
            {
                podid.ReceivedByClerkId = clerkid;
            }
            scservice.UpdatePurchaseOrderDetailItem(podlist);
            return true;
        }

        [HttpGet]
        [Route("/storeclerk/createav")]
        public AdjustmentVoucher CreateAdjustmentvoucher()
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            AdjustmentVoucher av = scservice.CreateAdjustmentVoucher(clerkid);
            return av;
        }


        //@author Guo Xiujuan
        [HttpGet]
        [Route("/storeclerk/adv")]
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = scservice.GetAllAdjustmentVoucher();
            return advlist;
        }
        [HttpGet]
        [Route("/storeclerk/retrievealldept")]
        public List<Department> RetrieveDepartment()
        {
            List<Department> deptlist = scservice.GetAllDepartment();
            return deptlist;
        }

        //@author Guo Xiujuan
        [HttpGet]
        [Route("/storeclerk/advdet/{advId}")]
        public List<AdjustmentVoucherDetail> GetAdvDetailsbyAdvId(string advId)
        {
            List<AdjustmentVoucherDetail> advdetails = scservice.GetAdvDetailsByAdvId(advId);
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

        //@author Guo Xiujuan
        [HttpPut]
        [Route("/storeclerk/UpdateAdjustmentDetails/")]
        public bool UpdataeAdjustmentDetails([FromBody]List<AdjustmentVoucherDetail> voucherDetails)
        {
            return scservice.UpdateAdjustmentVoucherDeatails(voucherDetails);
        }

        //@author Guo Xiujuan
        [HttpPut]
        [Route("/storeclerk/SubmitAdjustmentDetails/")]
        public bool SubmitAdjustmentDetails([FromBody]List<AdjustmentVoucherDetail> voucherDetails)
        {
            scservice.UpdateAdjustmentVoucherDeatails(voucherDetails);
            string adjustmentVoucherId = voucherDetails[0].AdjustmentVoucherId;
            scservice.ClerkSubmitAdjustmentVoucher(adjustmentVoucherId);
            return true;
        }

        //@author Guo Xiujuan
        [HttpGet]
        [Route("/storeclerk/findAdjustmentVoucher/{advId}")]
        public AdjustmentVoucher FindAdjustmentVoucherById(string advId)
        {
            AdjustmentVoucher av = scservice.FindAdjustmentVoucherById(advId);
            return av;
        }

        //@author Guo Xiujuan
        [HttpGet]
        [Route("/storeclerk/findAdjustmentVoucherbyClerk/")]
        public List<AdjustmentVoucher> FindAdjustmentVoucherByClerkId()
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            return scservice.FindAdjustmentVoucherByClerkId(clerkid);
        }

        //@author Guo Xiujuan
        [HttpGet]
        [Route("/storeclerk/FirstTenderbyProdutId/{ProductId}")]
        public TenderQuotation GetFirstTenderbyProdutId(string ProductId)
        {
            return scservice.GetFirstTenderbyProdutId(ProductId);
        }

        [HttpGet]
        [Route("/storeclerk/retformav")]
        public List<Retrieval> GetRetrievalFormCommentsForAdjustmentVoucher()
        {
            List<Retrieval> retrievalwithcomments = scservice.GetRetrievalFormCommentsForAdjustmentVoucher();
            if (retrievalwithcomments != null || retrievalwithcomments.Count != 0)
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


        [HttpDelete]
        [Route("/storeclerk/eav/{avId}")]
        public bool EmptyAdjustmentVoucher(string avId)
        {
            scservice.EmptyCreatedAdjustmentVoucher(avId);
            return true;
        }

    }
}
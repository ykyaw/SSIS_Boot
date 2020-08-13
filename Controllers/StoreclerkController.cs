using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Threading.Tasks;
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
            return reqlist;
        }
        [HttpGet]
        [Route("/storeclerk/rf/{deptID}")]
        public List<Requisition> getreqformByDeptId(string deptID)
        {
            List<Requisition> reqlist = scservice.getReqformByDeptId(deptID);
            return reqlist;
        }

        [HttpGet]
        [Route("/storeclerk/rfld/{reqId}")]
        public Requisition getreqformByReqId(int reqId)
        {
            Requisition req = scservice.getReqByReqId(reqId);
            return req;
        }

        [HttpPut] //TO FOLLOW UP
        [Route("/storeclerk/rfld/{reqId}")]
        public bool updateRequisitionCollectionTime([FromBody] Requisition r1)
        {
            try
            {
                int clerkid = (int)HttpContext.Session.GetInt32("Id");
                r1.AckByClerkId = clerkid;
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

        [HttpPost]
        [Route("/storeclerk/ret")]
        public Retrieval genretrievalform([FromBody] long date)
        {
            int clerkid = (int)HttpContext.Session.GetInt32("Id");
            List<Requisition> rq = scservice.getallreqformbydate(date);
            if (rq == null || rq.Count == 0)
            {
                throw new Exception("Sorry, there is no Requisition matching the provided date. Please try again");
            }
            Retrieval r1 = scservice.genretrievalform(date, clerkid);
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
                Retrieval r = r1;
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

            // send email to the department rep (PENDING)
            return dlist;
        }

        [HttpPost]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPOST] and pass in from body
        [Route("/storeclerk/updatesc")]
        public bool updatestockcard([FromBody] Transaction t1)
        {
            //for testing purpose 
            //Transaction t1 = new Transaction("C001", 1597211000, "supply to Math Department", -20, 530, 1, null); //August 12, 2020 13:43:20
            scservice.savetransaction(t1);
            return true;
        }
        [HttpPost]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPOST] and pass in from body
        [Route("/storeclerk/createpr")]
        public List<PurchaseRequestDetail> generatepurchaserequest([FromBody]List<String> productId)
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

            scservice.updatepurchaserequestitem(prdlist);
            //List<PurchaseRequestDetail> prdetailsfinal = scservice.getpurchasereq();
            return true;
        }

        //[HttpGet] //For testing oly
        [HttpPost]
        [Route("/storeclerk/generatequote")]
        public bool generatequotefrompr(List<PurchaseRequestDetail> prdlist)
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

            scservice.generatequotefrompr(prdlist);
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

            foreach (PurchaseOrderDetail podid in podlist)
            {
                scservice.updatepurchaseorderdetailitem(podid);
            }
            return true;
        }

        [HttpGet]
        [Route("/storeclerk/adv")]
        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = scservice.getAllAdjustmentVoucher();
            return advlist;
        }


    }
}
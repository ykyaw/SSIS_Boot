﻿using System;
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

        [HttpPut]
        [Route("/storeclerk/rfld/{reqId}")]
        public bool updatereqcollectiontime(Requisition req)
        {
            
            //To be followed up. Also include email service to rep
            Requisition req = scservice.getReqByReqId(reqId);
            return req;
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
        public List<TenderQuotation> gettop3supplier (string productId)
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
            return dlist;
        }

        [HttpPost]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPOST] and pass in from body
        [Route("/storeclerk/updatesc")]
        public bool updatestockcard ([FromBody] Transaction t1)
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
            //List<String> productid = new List<string> {"C001", "E002", "H031" };
            int currentpurchaserequestid = (int) DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            foreach (String id in productId)
            {
                PurchaseRequestDetail prd1 = new PurchaseRequestDetail();
                prd1.ProductId = id;
                prd1.Status = Status.PurchaseRequestStatus.created;
                prd1.PurchaseRequestId = currentpurchaserequestid;
                //prd1.CreatedByClerkId = 1;
                prd1.CreatedByClerkId = (int) HttpContext.Session.GetInt32("Id");
                scservice.addpurchaserequest(prd1);
            }
            List<PurchaseRequestDetail> prlist = scservice.getcurrentpurchaserequest(currentpurchaserequestid);
            return prlist;

        }
        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/storeclerk/updatepr")]
        public bool Updatepurchaserequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            //testing 
            //List<PurchaseRequestDetail> prdetails = scservice.getpurchasereq();
            //PurchaseRequestDetail prd1 = prdetails.Find(item => item.Id == 6);
            //prd1.ReorderQty = 5000;
            //prd1.VenderQuote = "QUO03";
            //prd1.SupplierId = "ALPA";
            //PurchaseRequestDetail prd2 = prdetails.Find(item => item.Id == 4);
            //prd2.ReorderQty = 100;
            //prd2.VenderQuote = "QUO04";
            //prd2.SupplierId = "ALPA";
            //List<PurchaseRequestDetail> prdlist = new List<PurchaseRequestDetail> { prd1, prd2 };

            foreach (PurchaseRequestDetail prd in prdlist)
            {
                scservice.updatepurchaserequestitem(prd);
            }
            //List<PurchaseRequestDetail> prdetailsfinal = scservice.getpurchasereq();
            return true;
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        /*      FOR TESTING ONLY
        [HttpGet] 
        [Route("/storeclerk/ret")]
        public Retrieval genretrievalform()
        {
            //long date = 99; //check for invalid date
            long date = 1596447000; // for creating of new
            //long date = 1595237400; // check for existing
            int clerkid = 1;
            List<Requisition> rq = scservice.getallreqformbydate(date);
            if (rq == null || rq.Count == 0)
            {
                throw new Exception("Sorry, there is no Requisition matching the provided date. Please try again");
            }
            Retrieval r1 = scservice.genretrievalform(date, clerkid);
            return r1;
        }*/



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
    }
}
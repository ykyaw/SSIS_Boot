﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
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
        [HttpGet]
        [Route("/storeclerk/supplier/{productId}")]
        public List<TenderQuotation> gettop3supplier (string productId)
        { 
            List<TenderQuotation> slist = scservice.gettop3suppliers(productId);
            return slist;
        }
    }
}
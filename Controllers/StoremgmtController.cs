﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class StoremgmtController : Controller
    {
        private IStoreManagerService smservice;

        public StoremgmtController(IStoreManagerService smservice)
        {
            this.smservice = smservice;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        //[HttpGet] //for testing
        [Route("/storemgmt/updatesupplier")]
        public bool updatetop3supplier([FromBody] List<TenderQuotation> tqlist)
        {
            //testing 
            //List<TenderQuotation> tqlist = new List<TenderQuotation>();
            smservice.updatetop3supplier(tqlist);
            return true;
        }
        [HttpGet]
        [Route("/storemgmt/retrievesuppliers")]
        public List<TenderQuotation> retrievesupplierbyproductId (string pdtid)
        {
            //string pdtid1 = "E032";
            List<TenderQuotation> tqlist = smservice.retrievesuppliers(pdtid);
            return tqlist;
        }

    }
}
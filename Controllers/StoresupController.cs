﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using SSIS_BOOT.Repo;

namespace SSIS_BOOT.Controllers
{
    public class StoresupController : Controller
    {
        private IStoreSupService ssservice;
        private IStoreClerkService scservice;

        public StoresupController(IStoreSupService ssservice, IStoreClerkService scservice)
        {
            this.ssservice = ssservice;
            this.scservice = scservice;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/storesup/voucher/{id}")]
        public AdjustmentVoucher GetAdjustmentVoucher(string id)
        {
            //string id2 = "031_007_2020";
            AdjustmentVoucher av = ssservice.getAdjVouchById(id);
            return av;
        }

        //[HttpGet]
        [HttpPut]
        [Route("/storesup/voucher/{id}")]
        public bool ApprovRejAdjustmentVoucher([FromBody]AdjustmentVoucher av)
        {
            // FOR TESTING ONLY
            
            //int approverid = 3;
            //AdjustmentVoucher av = new AdjustmentVoucher();
            //av.Id = "031_07_2020";
            //av.Status = Status.AdjVoucherStatus.approved;
            //av.InitiatedClerkId = 1;
            //av.InitiatedDate = 1596207600000;
            
            // END OF TEST

            int approverid = (int)HttpContext.Session.GetInt32("Id");
            try
            {
                ssservice.ApprovRejAdjustmentVoucher(av, approverid);
                return true;
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }
        }

        [HttpGet]
        [Route("/storesup/pr")]
        public List<PurchaseRequestDetail> getallpurchasereq()
        {
            List<PurchaseRequestDetail> prdetails = ssservice.getpurchasereq();
            return prdetails;
        }
        [HttpGet]
        [Route("/storesup/prdetails/{prid}")]
        public List<PurchaseRequestDetail> getprdetails(long prid)
        {
            List<PurchaseRequestDetail> prdetails = ssservice.getprdetails(prid);
            return prdetails;
        }
        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/storesup/updatepr")]
        public bool updatepurchaserequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            //testing 
            //long prid = 1593617400000;
            //List<PurchaseRequestDetail> prdlist = scservice.getprdetails(prid);
            //int supid = 2;

            int supid = (int)HttpContext.Session.GetInt32("Id");
            long responsedate = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            ssservice.updatepr(prdlist, supid, responsedate);
            return true;
        }


        [HttpGet]
        [Route("/storesup/allvoucher")]
        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = ssservice.getAllAdjustmentVoucher();
            List<AdjustmentVoucher> advlist2 = new List<AdjustmentVoucher>();
            foreach(AdjustmentVoucher a in advlist)
            {
                if(a.Status != Status.AdjVoucherStatus.created) //Supervisor/manager should not see adjustment voucher under creation status
                {
                    advlist2.Add(a);
                }
            }
            return advlist2;
        }

    }
}
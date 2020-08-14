using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SSIS_BOOT.Controllers
{
    public class StoresupController : Controller
    {
        private IStoreSupService ssservice;

        public StoresupController(IStoreSupService ssservice)
        {
            this.ssservice = ssservice;
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
        //[HttpPut]
        ////[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        //[Route("/storesup/updatepr")]
        //public bool updatepurchaserequest([FromBody] List<PurchaseRequestDetail> prdlist)
        //{
        //    //testing 
        //    //RequisitionDetail rd1 = new RequisitionDetail();
        //    //rd1.RequisitionId = 8;
        //    //rd1.ProductId = "C002";
        //    //rd1.QtyNeeded = 10;
        //    //RequisitionDetail rd2 = new RequisitionDetail();
        //    //rd2.RequisitionId = 8;
        //    //rd2.ProductId = "P013";
        //    //rd2.QtyNeeded = 10;
        //    //List<RequisitionDetail> rdlist = new List<RequisitionDetail>() { rd1, rd2 };

        //    ssservice.updatepr(prdlist);
        //    return true;
        //}


        [HttpGet]
        [Route("/storesup/allvoucher")]
        public List<AdjustmentVoucher> getAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = ssservice.getAllAdjustmentVoucher();
            return advlist;
        }

    }
}
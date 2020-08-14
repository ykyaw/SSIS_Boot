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
        [Route("/sup/voucher/{id}")]
        public AdjustmentVoucher GetAdjustmentVoucher(string id)
        {
            //string id2 = "031_007_2020";
            AdjustmentVoucher av = ssservice.getAdjVouchById(id);
            return av;
        }

        //[HttpGet]
        [HttpPut]
        [Route("/sup/voucher/{id}")]
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
    }
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;
using Microsoft.AspNetCore.Http;


/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
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
            AdjustmentVoucher av = ssservice.GetAdjVouchById(id);
            return av;
        }
        [HttpPut]
        [Route("/storesup/voucher/{id}")]
        public bool ApprovRejAdjustmentVoucher([FromBody]AdjustmentVoucher av)
        {
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
        public List<PurchaseRequestDetail> GetAllPurchaseReq()
        {
            List<PurchaseRequestDetail> prdetails = ssservice.GetPurchaseReq();
            return prdetails;
        }
        [HttpGet]
        [Route("/storesup/prdetails/{prid}")]
        public List<PurchaseRequestDetail> GetPrDetails(long prid)
        {
            List<PurchaseRequestDetail> prdetails = ssservice.GetPrDetails(prid);
            return prdetails;
        }
        [HttpPut]
        [Route("/storesup/updatepr")]
        public bool UpdatePurchaseRequest([FromBody] List<PurchaseRequestDetail> prdlist)
        {
            int supid = (int)HttpContext.Session.GetInt32("Id");
            long responsedate = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            ssservice.UpdatePr(prdlist, supid, responsedate);
            return true;
        }
        [HttpGet]
        [Route("/storesup/allvoucher")]
        public List<AdjustmentVoucher> GetAllAdjustmentVoucher()
        {
            List<AdjustmentVoucher> advlist = ssservice.GetAllAdjustmentVoucher();
            List<AdjustmentVoucher> advlist2 = new List<AdjustmentVoucher>();
            foreach (AdjustmentVoucher a in advlist)
            {
                if (a.Status != Status.AdjVoucherStatus.created) //Supervisor/manager should not see adjustment voucher under creation status
                {
                    advlist2.Add(a);
                }
            }
            return advlist2;
        }
    }
}
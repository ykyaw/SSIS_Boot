using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Product> getcatalogue()
        {
            List<Product> pdt = scservice.getallcat();
            return pdt;
        }

        //public List<PurchaseRequestDetail> getpurchasereq()
        //{
        //    List<PurchaseRequestDetail> prdetails = scservice.getpurchasereq();
        //    return prdetails;
        //}

    }
}
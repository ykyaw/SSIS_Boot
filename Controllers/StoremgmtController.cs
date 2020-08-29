using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
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

        [HttpPut]
        [Route("/storemgmt/updatesupplier")]
        public bool UpdateTop3Supplier([FromBody] List<TenderQuotation> tqlist)
        {
            smservice.UpdateTop3Supplier(tqlist);
            return true;
        }
        [HttpGet]
        [Route("/storemgmt/retrievesuppliers/{pdtid}")]
        public List<TenderQuotation> RetrieveSupplierByProductId(string pdtid)
        {
            List<TenderQuotation> tqlist = smservice.RetrieveSuppliers(pdtid);
            return tqlist;
        }

    }
}
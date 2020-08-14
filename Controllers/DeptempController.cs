using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class DeptempController : Controller
    {
        private IDepartmentEmpService deservice;
        public DeptempController(IDepartmentEmpService deservice)
        {
            this.deservice = deservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/deptemp/rfl")]
        public List<Requisition> getdeptreqlist()
        {
            //to be replaced by session of the user's departmentId
            string deptid = "CPSC";
            //string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> reqlist = deservice.getdeptreqlist(deptid);
            return reqlist;
        }
        [HttpGet]
        [Route("/deptemp/rfld/{reqId}")]
        public Requisition GetRequisitionDetails(int reqId)
        {
            Requisition req = deservice.getrfdetail(reqId);
            return req;
        }
        [HttpGet]
        [Route("/deptemp/catalogue")]
        public List<Product> getcatalogue()
        {
            List<Product> pdt = deservice.getallcat();
            return pdt;
        }

        //[HttpGet] //if testing
        [HttpPost]
        [Route("/deptemp/createRF")]
        public Requisition createRF()
        {
            //int empid = 3;
            //string deptid = "CPSC";
            int empid = (int)HttpContext.Session.GetInt32("Id");
            string deptid = (string)HttpContext.Session.GetString("DeptId");
            Requisition req = deservice.createrequisition(empid,deptid);
            return req;
        }
        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/deptemp/updateRF")]
        public Requisition updateRF([FromBody]List<RequisitionDetail> rdlist)
        {
            //testing [FromBody]List<RequisitionDetail> rdlist
            //to ensure that requisitionid is alr filled in
            //RequisitionDetail rd1 = new RequisitionDetail();
            //rd1.RequisitionId = 8;
            //rd1.ProductId = "C002";
            //rd1.QtyNeeded = 0;
            //RequisitionDetail rd2 = new RequisitionDetail();
            //rd2.RequisitionId = 8;
            //rd2.ProductId = "P013";
            //rd2.QtyNeeded = 10;
            //List<RequisitionDetail> rdlist = new List<RequisitionDetail>() { rd1, rd2 };

            Requisition req = deservice.updatereqform(rdlist);
            return req;
        }
        [HttpPut]
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/deptemp/submitrf")]
        public bool submitrf([FromBody] List<RequisitionDetail> rdlist)
        {
            //testing 
            //RequisitionDetail rd1 = new RequisitionDetail();
            //rd1.RequisitionId = 8;
            //rd1.ProductId = "C002";
            //rd1.QtyNeeded = 10;
            //RequisitionDetail rd2 = new RequisitionDetail();
            //rd2.RequisitionId = 8;
            //rd2.ProductId = "P013";
            //rd2.QtyNeeded = 10;
            //List<RequisitionDetail> rdlist = new List<RequisitionDetail>() { rd1, rd2 };

            deservice.submitrf(rdlist);
            return true;
        }




    }
}
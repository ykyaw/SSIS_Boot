﻿using System;
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
            //string deptid = "CPSC";
            string deptid = HttpContext.Session.GetString("DeptId");
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
        [HttpPost]
        [Route("/deptemp/saveRFdraft")]
        public Requisition savereqformdraft(List<RequisitionDetail> rdlist)
        {
            Requisition rq= deservice.updatereqform(rdlist);
            return rq;

        }


    }
}
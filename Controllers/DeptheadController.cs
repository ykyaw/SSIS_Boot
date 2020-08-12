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
    public class DeptheadController : Controller
    {
        private IDepartmentHeadService dhservice;
        public DeptheadController (IDepartmentHeadService dhservice)
        {
            this.dhservice = dhservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/depthead/rfl")]
        public List<Requisition> getdeptreqlist()
        {
            //to be replaced by session of the user's departmentId
            //string deptid = "CPSC";
            string deptid = HttpContext.Session.GetString("DeptId");
            List <Requisition> reqlist = dhservice.getdeptreqlist(deptid);
            return reqlist;
        }
        [HttpGet]
        [Route("/depthead/rfld/{reqId}")]
        public List<RequisitionDetail> GetRequisitionDetails(int reqId)
        {
            List < RequisitionDetail > rdlist = dhservice.getrfdetail(reqId);
            return rdlist;
        }


    }
}
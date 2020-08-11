using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public string test()
        {
            return "Hello world!";
        }

        public List<Requisition> getallreqbyrequester() //TK's sample, delete if not required
        {
            //Block of code to extract employee ID from session
            int empid = 6;
            List<Requisition> lr = deservice.findallreq(empid);
            return lr;
        }

    }
}
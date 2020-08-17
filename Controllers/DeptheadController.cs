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
        public Requisition GetRequisitionDetails(int reqId)
        {
            Requisition req = dhservice.getrfdetail(reqId);
            return req;
        }

        [HttpGet]
        [Route("/depthead/gae")]
        public List<Employee> GetAllDeptEmployee()
        {
            //For testing
            //string deptid = "COMM";
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Employee> empList = dhservice.GetAllDeptEmployee(deptid);
            return empList;
        }

        [HttpPut]
        [Route("/depthead/arr")]
        public bool ApprovRejRequisition([FromBody] Requisition req)
        {
            try
            {
                int deptHeadId = (int)HttpContext.Session.GetInt32("Id");
                req.ApprovedById = deptHeadId;
                dhservice.ApprovRejRequisition(req);
                return true;
            }
            catch (Exception m)
            {
                throw new Exception(m.Message);
            }

        }

        [HttpPut]
        [Route("/depthead/del")]
        public bool AssignDelegate([FromBody] Employee emp)
        {
            try
            {
                string deptid = (string)HttpContext.Session.GetString("DeptId");
                dhservice.AssignDelegate(emp, deptid);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("/depthead/adr/{empid}")]
        public bool AssignDeptRep(int empid)
        {
            try
            {
                string deptid = (string)HttpContext.Session.GetString("DeptId");
                dhservice.AssignDeptRep(empid, deptid);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





    }
}
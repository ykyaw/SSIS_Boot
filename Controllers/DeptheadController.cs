using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class DeptheadController : Controller
    {
        private IDepartmentHeadService dhservice;
        public DeptheadController(IDepartmentHeadService dhservice)
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
            List<Requisition> reqlist = dhservice.DeptHeadGetdeptReqlist(deptid);
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }

        [HttpGet]
        [Route("/depthead/dis")]
        public List<Requisition> getdeptdisbursement()
        {
            //to be replaced by session of the user's departmentId
            //string deptid = "ENGL";
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> dislist = dhservice.getdeptdisbursementlist(deptid);
            List<Requisition> sorteddislist = dislist.OrderByDescending(m => m.CreatedDate).ToList();
            return sorteddislist;
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
            //string deptid = "ENGL";
            //int empid = 5;
            string deptid = HttpContext.Session.GetString("DeptId");
            int empid = (int)HttpContext.Session.GetInt32("Id");
            List<Employee> empList = dhservice.GetAllDeptEmployee(deptid);
            foreach(Employee e in empList)
            {
                if(e.Id == empid)
                {
                    empList.Remove(e);
                    break;
                }
            }
            return empList;
        }

        [HttpPut]
        [Route("/depthead/arr")]
        public bool ApprovRejRequisition([FromBody] Requisition req)
        {
            try
            {     
                //add the current date to be the approved date.
                DateTime dateTime = DateTime.UtcNow.Date;
                DateTimeOffset dt = new DateTimeOffset(dateTime, TimeSpan.Zero).ToUniversalTime();
                long date = dt.ToUnixTimeMilliseconds();
                int approvedbyid = (int)HttpContext.Session.GetInt32("Id");
                req.ApprovalDate = date;
                req.ApprovedById = approvedbyid;
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
        public bool AssignDeptRep(int empid) //CHECK WHETHER HTTPPUT CAN PASS IN FROM URI WITHOUT BODY
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

        [HttpGet]
        [Route("/depthead/cdel")]
        public Employee GetCurrentDelegate()
        {
            string deptid = (string)HttpContext.Session.GetString("DeptId");
            Employee emp = dhservice.GetCurrentDelegate(deptid);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                throw new Exception("No department delegate assigned within this period");
            }
        }


        [HttpGet]
        [Route("/depthead/alldept")]
        public List<Department> GetAllDepartment()
        {
            List<Department> dlist = dhservice.GetAllDepartment();
            return dlist;
        }


    }
}
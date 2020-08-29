using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

/**
 * @author Choo Teck Kian, Pei Jia En, Jade Lim
 */
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
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> reqlist = dhservice.DeptHeadGetdeptReqlist(deptid);
            List<Requisition> sortedreqlist = reqlist.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }

        [HttpGet]
        [Route("/depthead/dis")]
        public List<Requisition> getdeptdisbursement()
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> dislist = dhservice.GetDeptDisbursementList(deptid);
            List<Requisition> sorteddislist = dislist.OrderByDescending(m => m.CollectionDate).ToList();
            return sorteddislist;
        }

        [HttpGet]
        [Route("/depthead/rfld/{reqId}")]
        public Requisition GetRequisitionDetails(int reqId)
        {
            Requisition req = dhservice.GetRfDetail(reqId);
            return req;
        }

        [HttpGet]
        [Route("/depthead/gae")]
        public List<Employee> GetAllDeptEmployee()
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            int empid = (int)HttpContext.Session.GetInt32("Id");
            List<Employee> empList = dhservice.GetAllDeptEmployee(deptid);
            int deptheadid = (int)dhservice.FindDepartmentById(deptid).HeadId;
            List<Employee> empList2 = new List<Employee>();
            foreach (Employee e in empList)
            {
                if (e.Id == empid || e.Id == deptheadid)
                {
                    empList2.Add(e);
                }
            }

            return empList.Except(empList2).ToList();
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

        [HttpGet]
        [Route("/depthead/cdel")]
        public Employee GetCurrentDelegate()
        {
            string deptid = (string)HttpContext.Session.GetString("DeptId");
            Employee emp = dhservice.GetCurrentDelegate(deptid);
            return emp;
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
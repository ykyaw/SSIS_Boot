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
            int empid = (int)HttpContext.Session.GetInt32("Id");
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> reqlist = deservice.getdeptreqlist(deptid);
            IEnumerable <Requisition> removed = from r in reqlist
                                          where r.Status == Status.RequsitionStatus.created && r.ReqByEmpId != empid //filter away requisition with status "created" that does not belong to the owner
                                          select r;
            List<Requisition> reqlist2 = reqlist.Except(removed.ToList()).ToList();
            List <Requisition> sortedreqlist = reqlist2.OrderByDescending(m => m.CreatedDate).ToList();
            return sortedreqlist;
        }

        [HttpGet]
        [Route("/deptemp/dis")]
        public List<Requisition> GetAllDeptDisbursement()
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            List<Requisition> dislist = deservice.GetAllDeptDisbursementList(deptid);
            List<Requisition> sorteddislist = dislist.OrderByDescending(m => m.CollectionDate).ThenByDescending(m=>m.CreatedDate).ToList();
            return sorteddislist;
        }


        [HttpGet]
        [Route("/deptemp/dis/{longdate}")]
        public List<RequisitionDetail> GetDeptDisbursementByDate(long longdate)
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            List<RequisitionDetail> rdl = deservice.GetDisbursementByDate(deptid, longdate);
            return rdl;
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
        [Route("/deptemp/createRF")]
        public Requisition createRF() 
        {
            try
            {
                int empid = (int)HttpContext.Session.GetInt32("Id");
                string deptid = (string)HttpContext.Session.GetString("DeptId");
                Requisition req = deservice.createrequisition(empid, deptid);
                return req;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        [HttpPost]
        [Route("/deptemp/hrf")]
        public Requisition createRFfromHistory([FromBody]List<RequisitionDetail> rdlist) 
        {
            try
            {
                int empid = (int)HttpContext.Session.GetInt32("Id");
                string deptid = (string)HttpContext.Session.GetString("DeptId");
                Requisition req = deservice.createrequisitionfromhistory(empid, deptid, rdlist);
                return req;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("/deptemp/updateRF")]
        public bool updateRF([FromBody]List<RequisitionDetail> rdlist)
        {
            deservice.updatereqform(rdlist);
            return true;
        }
        [HttpPost]
        [Route("/deptemp/submitrf")]
        public bool submitrf([FromBody] List<RequisitionDetail> rdlist)
        {
            deservice.submitrf(rdlist);
            return true;
        }

        [HttpGet]
        [Route("/deptemp/dept")]
        public Department GetDepartment()
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            Department d1 = deservice.GetDepartment(deptid);
            return d1;
        }

        [HttpGet]
        [Route("/deptemp/clist")]
        public List<CollectionPoint> GetAllCollectionPoint()
        {
            List<CollectionPoint> clist = deservice.GetAllCollectionPoint();
            return clist;
        }

        [HttpPut]
        [Route("/deptemp/ucp")]
        public bool UpdateCollectionPoint([FromBody] CollectionPoint cp)
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            try
            {
                deservice.UpdateCollectionPoint(deptid, cp);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return true;
        }

        [HttpPut]
        [Route("/deptemp/ack")]
        public bool AckItemReceived([FromBody]List<RequisitionDetail> rdlist)
        {
            try
            {
                int empid = (int)HttpContext.Session.GetInt32("Id");
                deservice.AckItemReceived(empid, rdlist);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/deptemp/drep")]
        public Employee GetCurrentDeptRep()
        {
            string deptid = (string)HttpContext.Session.GetString("DeptId");
            Department d1 = deservice.GetDepartment(deptid);
            Employee drep = deservice.FindEmployeeById((int)d1.RepId);
            return drep;
        }

        [HttpDelete]
        [Route("/deptemp/dreq/{reqId}")]
        public bool DeleteCreatedRequisition(int reqId)
        {
            deservice.DeleteCreatedRequisition(reqId);
            return true;
        }
    }
}
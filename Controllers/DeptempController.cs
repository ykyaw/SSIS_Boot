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

        //[HttpGet] //if testing
        [HttpPost]
        [Route("/deptemp/createRF")]
        public Requisition createRF()
        {
            try
            {
                //int empid = 3;
                //string deptid = "CPSC";
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
        //[HttpGet] //REMEMBER TO CHANGE BACK TO [HTTPPUT] and pass in from body
        [Route("/deptemp/updateRF")]
        public bool updateRF([FromBody]List<RequisitionDetail> rdlist)
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

            deservice.updatereqform(rdlist);
            return true;
        }
        [HttpPost]
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

        [HttpGet]
        [Route("/deptemp/dept")]
        public Department GetDepartment()
        {
            //string deptid = "CPSC"; //For Testing
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

        //[HttpGet]
        [HttpPut]
        [Route("/deptemp/ucp")]
        public bool UpdateCollectionPoint([FromBody] CollectionPoint cp)
        {
            //// FOR TESTING //
            //CollectionPoint c6 = new CollectionPoint("University Hospital", "11:30AM");
            //c6.Id = 6;
            //string deptid = "CPSC"; //For Testing
            //deservice.UpdateCollectionPoint(deptid, c6);
            //Department d1 = deservice.GetDepartment(deptid);
            //return d1;
            ////END OF TEST
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

        [HttpGet]
        [Route("/deptemp/dis/{longdate}")]
        public List<RequisitionDetail> GetDisbursementByDate(long longdate)
        {
            string deptid = HttpContext.Session.GetString("DeptId");
            List<RequisitionDetail> rdl = deservice.GetDisbursementByDate(deptid, longdate);
            return rdl;
        }


        [HttpPut]
        [Route("/deptemp/ack")]
        public bool AckItemReceived([FromBody]List<RequisitionDetail> rdlist)
        {
            try
            {
                int empid = (int)HttpContext.Session.GetInt32("Id");
                //string deptid = HttpContext.Session.GetString("DeptId");
                deservice.AckItemReceived(empid, rdlist);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
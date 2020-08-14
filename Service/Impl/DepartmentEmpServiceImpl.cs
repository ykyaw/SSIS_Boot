using Microsoft.AspNetCore.Http;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class DepartmentEmpServiceImpl : IDepartmentEmpService
    {
        private RequisitionRepo rrepo;
        private RequisitionDetailRepo rdrepo;
        private ProductRepo prepo;
        private EmployeeRepo erepo;

        public DepartmentEmpServiceImpl(RequisitionRepo rrepo, RequisitionDetailRepo rdrepo, ProductRepo prepo, EmployeeRepo erepo)
        {
            this.rrepo = rrepo;
            this.rdrepo = rdrepo;
            this.prepo = prepo;
            this.erepo = erepo;
        }
        public List<Requisition> getdeptreqlist(string deptId)
        {
            return rrepo.findreqformByDeptID(deptId);
        }
        public Requisition getrfdetail(int reqId)
        {
            Requisition req = rrepo.findreqByReqId(reqId);
            return req;
        }
        public List<Product> getallcat()
        {
            return prepo.findallcat();
        }
        public Requisition updatereqform(List<RequisitionDetail> rdlist)
        {
            foreach (RequisitionDetail rd in rdlist)
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.addreqformitem(rd);
                }
            }
            int requisitionId = (int)rdlist[0].RequisitionId;
            Requisition req = rrepo.findreqByReqId(requisitionId);
            return req;
        }


        public Requisition createrequisition(int empid,string deptid)
        {
            //create empty requisition with date,employee ID and departmentid
            Requisition newform = new Requisition();

            newform.ReqByEmpId = empid;
            newform.CreatedDate= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            newform.DepartmentId = deptid;
            newform.Status = Status.RequsitionStatus.created;

            return rrepo.saveNewRequisition(newform);
        }
        public bool submitrf(List<RequisitionDetail> rdlist)
        {
            foreach (RequisitionDetail rd in rdlist)
            {
                if (rd.QtyNeeded != 0)
                {
                    rdrepo.addreqformitem(rd);
                }
            }
            int requisitionId = (int)rdlist[0].RequisitionId;
            Requisition req = rrepo.findreqByReqId(requisitionId);

            req.Status = Status.RequsitionStatus.pendapprov;
            Requisition updatedreq = rrepo.updateRequisition(req);

            int deptemp = updatedreq.ReqByEmpId;
            Employee depthead = erepo.findSupervisorByEmpId(deptemp);

            //send email to dept manager(PENDING)
            // if (supervisor !=null){}

            return true;
            
            
        }


    }
}

using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class RequisitionRepo
    {
        private SSISContext dbcontext;
        public RequisitionRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<Requisition> findallreqform()
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m=>m.Department).Include(m => m.ReqByEmp)
                .Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.ReceivedByRep).Include(m => m.AckByClerk)
                .Include(m => m.CollectionPoint).Include(m => m.RequisitionDetails).ToList();
            return lr;
        }
        public List<Requisition> findreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).Include(m => m.ReqByEmp)
                .Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.ReceivedByRep).Include(m => m.AckByClerk)
                .Include(m => m.CollectionPoint).Include(m => m.RequisitionDetails).Where(m => m.DepartmentId == deptID).ToList();
            return lr;
        }
        public List<Requisition> findrequsitionbycollectiondate(long date)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product).Include(m=>m.Department).Where(m => m.CollectionDate == date).ToList();
            return lr;
        }
        
    }
}

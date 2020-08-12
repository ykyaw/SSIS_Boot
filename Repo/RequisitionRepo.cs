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
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails).
        }
        public List<Requisition> findreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m => m.Department).Where(m => m.DepartmentId == deptID).ToList();
            return lr;
            // .Include(m => m.ReqByEmp).Include(m => m.ApprovedBy).Include(m => m.ProcessedByClerk).Include(m => m.RequisitionDetails)
        }
        public List<Requisition> findrequsitionbycollectiondate(long date)
        {
            List<Requisition> lr = dbcontext.Requisitions.Include(m=>m.RequisitionDetails).ThenInclude(m=>m.Product).Include(m=>m.Department).Where(m => m.CollectionDate == date).ToList();
            return lr;
        }
        
    }
}

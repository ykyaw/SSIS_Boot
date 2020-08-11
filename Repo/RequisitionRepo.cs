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

        public List<Requisition> findallreqbyempid(int empid)
        {
            List<Requisition> lr = dbcontext.Requisitions.Where(m => m.ReqByEmpId == empid).ToList();
            return lr;
        }
        public List<Requisition> findallreqform()
        {
            List<Requisition> lr = dbcontext.Requisitions.ToList();
            return lr;
        }
        public List<Requisition> findreqformByDeptID(string deptID)
        {
            List<Requisition> lr = dbcontext.Requisitions.Where(m => m.DepartmentId == deptID).ToList();
            return lr;
        }
        public List<Requisition> findrequsitionbycollectiondate(long date)
        {
            List<Requisition> lr = dbcontext.Requisitions.Where(m => m.CollectionDate == date).ToList();
            return lr;
        }
        
    }
}

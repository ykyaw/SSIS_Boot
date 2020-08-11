using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class DepartmentEmpServiceImpl : IDepartmentEmpService
    {
        private RequisitionRepo rRepo;
        public DepartmentEmpServiceImpl(RequisitionRepo rRepo)
        {
            this.rRepo = rRepo;
        }
        
        
        public List<Requisition> findallreq(int empid)
        {
            List<Requisition> lr = rRepo.findallreqbyempid(empid);
            return lr;

        }
    }
}

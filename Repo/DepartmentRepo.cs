using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class DepartmentRepo
    {
        private SSISContext dbcontext;
        public DepartmentRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<Department> findalldepartment() 
        {
            List<Department> dlist = dbcontext.Departments.ToList();
            return dlist;

        }

    }
}

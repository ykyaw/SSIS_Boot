using Microsoft.EntityFrameworkCore;
using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class EmployeeRepo
    {
        private SSISContext dbcontext;

        public EmployeeRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Employee Login(Employee emp)
        {
            return dbcontext.Employees.Include(m=>m.Department)
                .Where(item => item.Email == emp.Email && item.Password == emp.Password)
                .FirstOrDefault();
        }

        public Employee FindUserByEmail(string email)
        {
            return dbcontext.Employees.Include(m => m.Department)
                .Where(item => item.Email == email)
                .FirstOrDefault();
        }
        public Employee findempById(int empid)
        {
            return dbcontext.Employees.Where(item => item.Id == empid).FirstOrDefault();
        }
    }
}

using Microsoft.Data.SqlClient;
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
            return dbcontext.Employees.Include(m => m.Department)
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

        public Employee findSupervisorByEmpId(int empId)
        {
            Employee emp = dbcontext.Employees.FirstOrDefault(x => x.Id == empId);
            if (emp.ManagerId != null)
            {
                int supervisorid = (int)emp.ManagerId;
                return dbcontext.Employees.Where(item => item.Id == supervisorid).FirstOrDefault();
            }
            return null;
        }

        public List<Employee> findEmpByDept(string deptid)
        {
            List<Employee> emplist = dbcontext.Employees.Include(m => m.Department).Include(m => m.Manager).Where(m => m.DepartmentId == deptid).ToList();
            return emplist;
        }

        public Employee AssignDelegateDate(Employee emp)
        {
            try
            {
                Employee original = dbcontext.Employees.FirstOrDefault(m => m.Id == emp.Id);
                if (original != null)
                {
                    original.DelegateFromDate = emp.DelegateFromDate;
                    original.DelegateToDate = emp.DelegateToDate;
                }
                dbcontext.SaveChanges();
                return original;
            }
            catch (Exception)
            {
                throw new Exception("Error saving delegate dates");
            }

        }
        public Employee getcurrentdelegate(long submitdate, string deptid)
        {
            Employee e = new Employee();
            List<Employee> allempindept = dbcontext.Employees.Where(m => m.DepartmentId == deptid).ToList();
            foreach (Employee emp in allempindept)
            {
                if (submitdate > emp.DelegateFromDate && submitdate < emp.DelegateToDate)
                {
                    e = emp;
                    break;
                }
            }
            return e;
        }
    }
}

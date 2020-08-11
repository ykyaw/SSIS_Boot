using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class EmployeeServiceImpl : IEmployeeService
    {

        private EmployeeRepo employeeRepo;

        public EmployeeServiceImpl(EmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public Employee Login(Employee emp)
        {
            return employeeRepo.Login(emp);
        }

        public Employee FindUserByEmail(string email)
        {
            return employeeRepo.FindUserByEmail(email);
        }
    }
}

using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IEmployeeService
    {
        public Employee Login(Employee user);

        public Employee FindUserByEmail(string email);
    }
}

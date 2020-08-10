using SSIS_BOOT.DB;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Repo
{
    public class UserRepo
    {
        private SSISContext dbcontext;

        public UserRepo(SSISContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Employee Login(Employee user)
        {
            return dbcontext.Employees
                .Where(item => item.Email == user.Email && item.Password == user.Password)
                .FirstOrDefault();
        }

        public Employee FindUserByEmail(string email)
        {
            return dbcontext.Employees
                .Where(item => item.Email == email)
                .FirstOrDefault();
        }
    }
}

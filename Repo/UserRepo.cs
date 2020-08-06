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

        public User Login(User user)
        {
            return dbcontext.User
                .Where(item => item.email == user.email && item.password == user.password)
                .FirstOrDefault();
        }

        public User FindUserByEmail(string email)
        {
            return dbcontext.User
                .Where(item => item.email == email)
                .FirstOrDefault();
        }
    }
}

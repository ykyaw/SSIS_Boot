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

        public bool Login(User user)
        {
            List<User> users=dbcontext.User
                .Where(item => item.username == user.username && item.password == user.password)
                .ToList<User>();
            return users.Count() > 0;
        }
    }
}

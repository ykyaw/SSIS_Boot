using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Impl
{
    public class UserServiceImpl : IUserService
    {

        private UserRepo userRepo;

        public UserServiceImpl(UserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public User Login(User user)
        {
            return userRepo.Login(user);
        }

        public User FindUserByEmail(string email)
        {
            return userRepo.FindUserByEmail(email);
        }
    }
}

﻿using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Service.Interfaces
{
    public interface IUserService
    {
        public User Login(User user);

        public User FindUserByEmail(string email);
    }
}

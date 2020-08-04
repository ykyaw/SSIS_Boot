using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Components;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Impl;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public string Verify([FromBody] Result result)
        {
            User user= System.Text.Json.JsonSerializer.Deserialize<User>(result.Value.ToString());
            result.Value = userService.Login(user);
            return System.Text.Json.JsonSerializer.Serialize(result);
        }

    }
}
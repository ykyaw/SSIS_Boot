﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSIS_BOOT.Controllers
{
    public class DeptheadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Components.JWT.Interfaces;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class LoginController : Controller
    {

        private readonly IEmployeeService employeeService;
        private readonly IAuthService authService;

        public LoginController(IEmployeeService employeeService, IAuthService authService)
        {
            this.employeeService = employeeService;
            this.authService = authService;
        }

        /**
         * test token 
         * json web token is carried by the http request header
         * stored in Authorization and starts with the 'Bearer' string
         * @author WUYUDING
         */
        public string Index()
        {
            string result = "";
            string authHeader = Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                string token = authHeader.Substring("Bearer ".Length).Trim();
                if (!authService.IsTokenValid(token))
                {
                    result = "invalid token";
                }
                else
                {
                    //decrypt the token and get the infomation store in token
                    List<Claim> claims = authService.GetTokenClaims(token).ToList();
                    Employee user = new Employee();
                    user.Name = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                    user.Email = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value;
                    string expired= claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Expired)).Value;
                    result = expired;
                }
            }
            else
            {
                result = "no token";
            }
            return result;
        }


        /**
         * Verify user email and password
         * if email and password are correct, 
         * generate token and append it in cookie with cookie name 'token'(for .net)
         * and return it in result.Value(for android)
         * else return result with value null
         * 
         * @author WUYUDING
         */
         [HttpPost]
        public Dictionary<string, Object> Verify([FromBody] Employee employee)
        {
            employee = employeeService.Login(employee);
            if (employee != null)
            {
                //Delegate check
                long currenttime = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (employee.Role == "de" && currenttime > employee.DelegateFromDate && currenttime < employee.DelegateToDate)
                {
                    employee.Role = "dh";
                }

                string token = authService.GenerateToken(employee);
                Dictionary<string, Object> result = new Dictionary<string, object>();
                result.Add("token", token);
                employee = new Employee()
                {
                    Name = employee.Name,
                    Role = employee.Role,
                    DelegateFromDate = employee.DelegateFromDate,
                    DelegateToDate = employee.DelegateToDate

                };
                result.Add("employee", employee);
                Response.Cookies.Append("token", token);
                return result;
            }
            else
            {
                throw new Exception("email or password incorrect.");
            }
        }

        [HttpPost]
        public Employee Test([FromBody]Employee user)
        {
            user.Name = "haala";
            return user;
        }

    }
}
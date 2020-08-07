using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSIS_BOOT.Components;
using SSIS_BOOT.Components.JWT.Interfaces;
using SSIS_BOOT.Models;
using SSIS_BOOT.Service.Impl;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserService userService;
        private readonly IAuthService authService;

        public LoginController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
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
                    User user = new User();
                    user.username = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                    user.email = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value;
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
        public string Verify([FromBody] User user)
        {
            user = userService.Login(user);
            if (user != null)
            {
                string token = authService.GenerateToken(user);
                Response.Cookies.Append("token", token);
                return token;
            }
            else
            {
                throw new Exception("email or password incorrect.");
            }
        }

        [HttpPost]
        public User Test([FromBody]User user)
        {
            user.username = "haala";
            return user;
        }

    }
}
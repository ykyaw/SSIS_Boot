using Microsoft.AspNetCore.Http;
using SSIS_BOOT.Common;
using SSIS_BOOT.Components.JWT.Interfaces;
using SSIS_BOOT.Models;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


/**
 * check user token which is store in request header
 * @author WUYUDING
 */
namespace SSIS_BOOT.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate next;

        public AuthMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context, IAuthService authService, EmployeeRepo userRepo)
        {
            string controller = (string)context.Request.RouteValues["controller"];
            string action = (string)context.Request.RouteValues["action"];
            //get sessionId from cookie
            if ((controller != "Login"||action!= "Verify")&&(controller != "Home" || action != "Error") )
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Bearer"))
                {
                    string token = authHeader.Substring("Bearer ".Length).Trim();
                    if (!authService.IsTokenValid(token))
                    {
                        context.Response.StatusCode = CommonConstant.ErrorCode.INVALID_TOKEN;
                        return;
                    }
                    else
                    {
                        //decrypt token
                        List<Claim> claims = authService.GetTokenClaims(token).ToList();
                        Employee user = new Employee();
                        user.Name = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value;
                        user.Email = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value;
                        user= userRepo.FindUserByEmail(user.Email);

                        if (user == null)
                        {
                            context.Response.StatusCode = CommonConstant.ErrorCode.INVALID_TOKEN;
                            return;
                        }
                        //Delegate check
                        long currenttime = (long)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        if (user.Role == "de" && currenttime > user.DelegateFromDate && currenttime < user.DelegateToDate)
                        {
                            user.Role = "dh";
                        }
                        bool t=CommonConstant.Authorization[user.Role].Contains(controller);
                        //check permission
                        //if (!CommonConstant.Authorization[user.Role].Contains(controller))
                        //{
                        //    context.Response.StatusCode = CommonConstant.ErrorCode.NO_PERMISSIN;
                        //    return;
                        //}

                        token = authService.GenerateToken(user);
                        context.Response.Cookies.Append("token", token);
                        try
                        {
                            context.Session.SetInt32("Id", user.Id);
                            context.Session.SetString("Name", user.Name);
                            context.Session.SetString("DeptId", user.DepartmentId);
                            context.Session.SetString("DeptName", user.Department.Name);
                        }catch(Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    context.Response.StatusCode = CommonConstant.ErrorCode.INVALID_TOKEN;
                    return;
                }
            }
            await next(context);
        }
    }
}

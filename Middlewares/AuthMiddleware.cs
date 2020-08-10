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


        public async Task Invoke(HttpContext context, IAuthService authService, UserRepo userRepo)
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
                        token= authService.GenerateToken(user);
                        context.Response.Cookies.Append("token", token);
                        if (user == null)
                        {
                            context.Response.StatusCode = CommonConstant.ErrorCode.INVALID_TOKEN;
                            return;
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

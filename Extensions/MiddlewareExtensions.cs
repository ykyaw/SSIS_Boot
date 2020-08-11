using Microsoft.AspNetCore.Builder;
using SSIS_BOOT.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
        {
            //app.UseMiddleware<AuthMiddleware>();
            app.UseMiddleware<ExceptionMiddleWare>();
            return app;
        }
    }
}

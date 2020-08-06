using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSIS_BOOT.Components.JWT.Impl;
using SSIS_BOOT.Components.JWT.Interfaces;
using SSIS_BOOT.DB;
using SSIS_BOOT.Extensions;
using SSIS_BOOT.Repo;
using SSIS_BOOT.Service.Impl;
using SSIS_BOOT.Service.Interfaces;

namespace SSIS_BOOT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IAuthService, JWTService>();
            services.AddScoped<UserRepo>();
            //inject dbcontext
            services.AddDbContext<SSISContext>(opt =>
                opt.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DbConn")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,SSISContext dbcontext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddlewareExtensions();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //dbcontext.Database.EnsureDeleted();
            //dbcontext.Database.EnsureCreated();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using HomeLoanManagementSystem.Repository.UserRepo;
using HomeLoanManagementSystem.Repository.AdminRepo;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HomeLoanManagementSystem
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {

                options.Cookie.Name = "MyCookie";
                options.LoginPath = "/User/login";
                options.SlidingExpiration = false;
                
                });
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.IsEssential = true;
                

            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => {

                   options.Cookie.Name = "MyCookie";
                   options.LoginPath = "/Employee/login";
                   options.SlidingExpiration = false;

                   options.Cookie.Name = "MyCookie1";
                   options.LoginPath = "/Admin/login";
                   options.SlidingExpiration = false;



               });
            services.AddDbContext<CodeFirstContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DbCon")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

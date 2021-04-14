using INTEX2Mock.Data;
using INTEX2Mock.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2Mock
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
            string mummyDBConnect = Environment.GetEnvironmentVariable("db_connect_mum");
            string AuthDBConnect = Environment.GetEnvironmentVariable("db_connect_auth");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection") + AuthDBConnect));
            //services.AddDbContext<MummyDbContext>(options =>
            //options.UseSqlServer(
            //        Configuration.GetConnectionString("MummyConnection")));
            //services.AddDbContext<PWOIKMContext>(options =>
            //options.UseSqlServer(
            //        Configuration.GetConnectionString("FinalMummyConnection")));


            services.AddDbContext<PWOIKMContext>(options =>
            options.UseSqlServer(
                    Configuration.GetConnectionString("FinalMummyConnection") + mummyDBConnect));


            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthorization(options => {
                options.AddPolicy("readpolicy",
                    builder => builder.RequireRole("Admin", "Researcher", "Unassigned"));
                options.AddPolicy("writepolicy",
                    builder => builder.RequireRole("Admin", "Researcher"));
                options.AddPolicy("managepolicy",
                    builder => builder.RequireRole("Admin"));
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "pagenum",
                    "ViewMummyRecords/{pagenum}",
                    new { Controller = "Home", action = "ViewMummyRecords" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

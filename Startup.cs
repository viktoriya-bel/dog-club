using dog_club.Data;
using dog_club.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dog_club_site
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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<dog_club.testdbContext>();
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/Login");
                });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            var context = app.ApplicationServices.GetRequiredService<dog_club.testdbContext>();
            InitDataDb.Initialize(context);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "profile",
                    defaults: new { controller = "Lk", action = "Profile" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "owners",
                    defaults: new { controller = "Owners", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "logout",
                    defaults: new { controller = "Auth", action = "Logout" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "roles",
                    defaults: new { controller = "Roles", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "users",
                    defaults: new { controller = "Users", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "groups",
                    defaults: new { controller = "Groups", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "breeds",
                    defaults: new { controller = "Breeds", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "rewards",
                    defaults: new { controller = "Rewards", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "dogs",
                    defaults: new { controller = "Dogs", action = "Index" });

            });
        }
    }
}

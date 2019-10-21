using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaraKhezriCrudTest.Models;

namespace SaraKhezriCrudTest
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Dbctx>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CustomerConnectionString")
                    , o => o.MigrationsAssembly("SaraKhezriCrudTest"));

                //options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);
            });

            //services.AddTransient<Dbctx, Dbctx>();
            services.AddTransient<Repository, Repository>();
            services.AddTransient<CustomerCommands, CustomerCommands>();
            services.AddTransient<CustomerQueries, CustomerQueries>();

            //var ctx = new Dbctx(
            //    new DbContextOptionsBuilder<Dbctx>()
            //    .UseSqlServer(Configuration.GetConnectionString("TestDatabase")).Options);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Customer}/{action=Find}/{id?}");
            //});

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customer}/{action=Find}/{id?}");
            });
        }

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseMvc(routes =>
        //    routes.MapRoute("default"
        //                  , "api/{controller=Values}/{action=Wipe}/{id?}"));
        //}
    }
}

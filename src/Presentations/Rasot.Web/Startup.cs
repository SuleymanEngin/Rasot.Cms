using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rasot.Core.Caching;
using Rasot.Core.Infrastructures;
using Rasot.Data;
using Rasot.Infrastructure;
using Rasot.MemoryCache;
using Rasot.Service.Services.Customers;
using Rasot.Web.Factories;
using Rasot.Web.Framework.Extensions;

namespace Rasot.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; set; }
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

            GlobalConfiguration.ContentRootPath= Environment.ContentRootPath;
            GlobalConfiguration.WebRootPath = Environment.WebRootPath;

            services.AddModules(GlobalConfiguration.ContentRootPath);
            services.AddDbContext<RasotDbContext>(options =>
            {

                options.UseMySQL(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });
           
            services.AddHttpClient();
            services.AddScoped<IDbContext, RasotDbContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddMemoryCacheManager();

            var asseml = AppDomain.CurrentDomain.GetAssemblies();

            #region Factory

            services.AddTransient<ICustomerModelFactory, CustomerModelFactory>();

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRasotMvc();
        }
    }
}

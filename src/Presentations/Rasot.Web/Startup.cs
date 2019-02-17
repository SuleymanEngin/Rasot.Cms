using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Rasot.Core.Infrastructures;
using Rasot.Data;
using Rasot.Infrastructure;
using Rasot.MemoryCache;
using Rasot.Service.Services.Authentications;
using Rasot.Service.Services.Categories;
using Rasot.Service.Services.Contents;
using Rasot.Service.Services.Customers;
using Rasot.Web.Factories;
using Rasot.Web.Framework.Extensions;
using System;

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

            services.AddRouting();
            services.AddModules(GlobalConfiguration.ContentRootPath);
            services.AddDbContext<RasotDbContext>(options =>
            {

                options.UseMySQL(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });
           
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddScoped<IDbContext, RasotDbContext>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddMemoryCacheManager();


            var AuthenticateScheme = "Authentication";


            services.AddAuthentication(option => {
                option.DefaultScheme = AuthenticateScheme;
                option.DefaultSignInScheme = "ExternalAuthentication";
            })
            .AddCookie(AuthenticateScheme, options =>
            {
                options.Cookie.Name = $"Web.{AuthenticateScheme}";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            });


            #region Factory

            services.AddTransient<ICustomerModelFactory, CustomerModelFactory>();
            services.AddTransient<IPostModelFactory, PostModelFactory>();

            #endregion
            services.AddRasotMvc(GlobalConfiguration.Modules);


        
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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRasotMvc();
        }
    }
}

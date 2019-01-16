using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Rasot.Web.Framework.RasotRoute;

namespace Rasot.Web.Framework.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder UseRasotMvc(this IApplicationBuilder app)
        {
           app.UseMvc(routes =>
           {
             
              routes.Routes.Add(new GenericRoute(routes.DefaultHandler));

               routes.MapRoute(
                   name: "areaRoute",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

               routes.MapRoute(
                   "default",
                   "{controller=Home}/{action=Index}/{id?}");

           });
          return app;
        }
    }
}

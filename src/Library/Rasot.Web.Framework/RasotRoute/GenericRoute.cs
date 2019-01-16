using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Rasot.Web.Framework.RasotRoute
{
    public class GenericRoute  :IRouter
    {
        private readonly IRouter _target;

        public GenericRoute(IRouter target)
        {
            _target = target;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {

            return null;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;
            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                requestPath = requestPath.Substring(1);
            }

            if (requestPath == "cms/detail")
            {

                var currentRouteData = context.RouteData;
                var newRouteData = new RouteData(currentRouteData);

            
                newRouteData.Values["controller"] = "Cms";
                newRouteData.Values["action"] = "Detail";
            

                context.RouteData = newRouteData;
            }


            await _target.RouteAsync(context);
        }
    }
}

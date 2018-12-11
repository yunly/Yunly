using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Internal;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : IRouter
    {
        private string[] urls;
        private IRouter mvcRoute;

        public LegacyRoute(IServiceProvider services, params string[] targetUrls)
        {
            urls = targetUrls;
            mvcRoute = services.GetRequiredService<MvcRouteHandler>();
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            if (context.Values.ContainsKey("legacyUrl"))
            {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url))
                {
                    return new VirtualPathData(this, url);
                }
            }
            return null;
        }

        /// <summary>
        /// The RouteAsync method is responsible for assessing whether a request can be handled and, 
        /// if it can, managing the process through to generating the response sent back to the client.
        /// This process is performed asynchronously, which is why the RouteAsync method returns a Task.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task RouteAsync(RouteContext context)
        {
            string requestedUrl = context.HttpContext.Request.Path.Value.TrimEnd('/');
            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase))
            {
                //context.Handler = async ctx => {
                //    HttpResponse response = ctx.Response;
                //    byte[] bytes = Encoding.ASCII.GetBytes($"URL: {requestedUrl}");
                //    await response.Body.WriteAsync(bytes, 0, bytes.Length);
                //};


                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);
            }

            
           // return Task.CompletedTask;
        }
    }
}

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace ConfiguringApps.Infrastructure
{
    /// <summary>
    /// Information about the HTTP request and the response that will be returned to the client is provided through the HttpContext argument to the Invoke method.
    /// I describe the HttpContext class and its properties in Chapter 17, but for this chapter, 
    /// it is enough to know that the Invoke method inspects the HTTP request and checks to see whether the request has been sent to the /middleware URL. 
    /// If it has, then a simple text response is sent to the client; if a different URL has been used, then the request is forwarded to the next component in the chain.
    /// </summary>
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptime;
        public ContentMiddleware(RequestDelegate next, UptimeService up)
        {
            nextDelegate = next;
            uptime = up;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync($"This is from the content middleware uptime: {uptime.Uptime} ms", Encoding.UTF8);
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}

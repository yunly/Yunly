using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ControllersAndActions
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();                
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            ///The UseSession method adds a middleware component to the pipeline that associates session data with requests 
            ///and adds cookies to responses to ensure that future requests can be identified. 
            ///The UseSession method must be called before the UseMvc method 
            ///so that the session component can intercept requests before they reach MVC middleware and can modify responses after they have been generated.
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }
    }
}

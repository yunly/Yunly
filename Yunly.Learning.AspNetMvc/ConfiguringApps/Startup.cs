using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();

            
            services.AddMvc();

                                    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">This interface defines the functionality required to set up an application’s middleware pipeline.</param>
        /// <param name="env">This interface defines the functionality required to differentiate between different types of environment, such as development and production.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseMiddleware<ErrorMiddleware>();
            //app.UseMiddleware<BrowserTypeMiddleware>();
            //app.UseMiddleware<ShortCircuitMiddleware>();
            //app.UseMiddleware<ContentMiddleware>();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();



            ///This method sets up the MVC middleware components with the default route.
            //  app.UseMvcWithDefaultRoute();

            /// This method sets up the MVC middleware components using a custom routing configuration specified using a lambda expression.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(context => context.Response.WriteAsync(
            //    $"ApplicationName: { env.ApplicationName} \n" +
            //    $"ContentRootFileProvider: { env.ContentRootFileProvider }\n" +
            //    $"ContentRootPath: { env.ContentRootPath }\n" +
            //    $"EnvironmentName: { env.EnvironmentName }\n" +
            //    $"WebRootPath: { env.WebRootPath }\n" +
            //    $"WebRootFileProvider: { env.WebRootFileProvider }\n"

            //    ));


        }
    }
}


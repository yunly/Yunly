using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Views.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        

        public Startup(ILogger<Startup> logger)
        {
            _logger = logger;
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
//            _logger.LogInformation("Hello world");



            services.AddMvc();
            //services.Configure<MvcViewOptions>(options =>
            //{
            //options.ViewEngines.Insert(0, new DebugDataViewEngine());
            //    foreach (var engine in options.ViewEngines)
            //        _logger.LogInformation($"---Engine: {engine.ToString()}");
            //});

            services.Configure<RazorViewEngineOptions>(options => {
                options.ViewLocationExpanders.Add(new SimpleExpander());
                options.ViewLocationExpanders.Add(new ColorExpander());
            }
            );
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

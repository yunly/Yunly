﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ApiControllers.Models;
using Microsoft.Net.Http.Headers;

namespace ApiControllers
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, MemoryRepository>();

            //services.AddMvc();

            ///Enable XML formatting
            //services.AddMvc().AddXmlDataContractSerializerFormatters();

            ///set and manage the mappings
            ///SetMediaTypeMappingForFormat method to create a new mapping 
            ///so that the shorthand xml will refer to the application / xml format
            services.AddMvc().AddXmlDataContractSerializerFormatters().AddMvcOptions(
                opts=>
                {
                    opts.FormatterMappings.SetMediaTypeMappingForFormat(
                        "xml",
                        new MediaTypeHeaderValue("application/xml")
                        );

                    ///control whether the Accept header is fullyrespected
                    opts.RespectBrowserAcceptHeader = true;

                    ///used to control whether a 406 - Not Acceptable response will be sent to the client 
                    ///if there is no suitable format available.
                    opts.ReturnHttpNotAcceptable = true;
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

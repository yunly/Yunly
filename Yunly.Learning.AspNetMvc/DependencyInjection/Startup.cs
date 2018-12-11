﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;

namespace DependencyInjection
{
    public class Startup
    {

        private IHostingEnvironment env;

        public Startup(IHostingEnvironment hostEnv) => env = hostEnv;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddTransient<IRepository>(provider =>
            {
                if (env.IsDevelopment())
                {
                    var x = provider.GetService<MemoryRepository>();
                    return x;
                }
                else
                {
                    return new AlternateRepository();
                }
            });
            services.AddTransient<MemoryRepository>();
            */

            //services.AddScoped<IRepository, MemoryRepository>();
            services.AddTransient<IRepository, AlternateRepository>();


            //TypeBroker.SetRepositoryType<AlternateRepository>();

            //services.AddTransient<IRepository, MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddScoped<ProductTotalizer>();

            
            services.AddMvc();
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
            app.UseMvcWithDefaultRoute();
        }
    }
}

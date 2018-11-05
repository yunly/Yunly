using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:SportStoreProducts:ConnectionString"])
                );

            ///extended the Entity Framework Core configuration to register the context class
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:SportStoreIdentity:ConnectionString"])
                );

            
            ///used the AddIdentity method to set up the Identity services using the built-in classes to represent users and roles.
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            ///replace the fake repository with the real one
            services.AddTransient<IProductRepository, EFProductRepository>();



            ///create a service for the Cart class
            ///The AddScoped method specifies that the same object should be used to satisfy related requests for Cart instances.
            ///How requests are related can be configured, but by default, 
            ///it means that any Cart required by components handling the same HTTP request will receive the same object.
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ///Registering the Order Repository Service in the Startup.cs File in the SportsStore Folder
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            ///tells ASP.NET Core that when a component,such as a controller, needs an implementation of the IProductRepository interface, 
            ///it should receive an instance of the FakeProductRepository class. 
            ///
            ///The AddTransient method specifies that a new FakeProductRepository object should be created each time 
            ///the IProductRepository interface is needed.
            //services.AddTransient<IProductRepository, FakeProductRepository>();

            services.AddMvc();

            ///sets up the in-memory data store
            services.AddMemoryCache();

            ///registers the services used to access session data
            services.AddSession();
        }  

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// It is important that you add the new route before the Default one that is already in the method. 
        /// As you will learn in Chapter 15, the routing system processes routes in the order they are listed, 
        /// and I need the new route to take precedence over the existing one.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }



            app.UseStaticFiles();

            ///allows the session system to automatically associate requests with sessions when they arrive from the client
            app.UseSession();

            ///set up the components that will intercept requests and responses to implement the security policy.
            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" }
                 );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Admin",
                        action = "Index",
                        productPage = 1
                    }
                );

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });


            //SeedData.EnsurePopulated(app);
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}

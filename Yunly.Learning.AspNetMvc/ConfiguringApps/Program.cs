using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ConfiguringApps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            BuildWebHost(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            new WebHostBuilder()

            ///This method configures the Kestrel web server, as described in the “Using Kestrel Directly” sidebar.
            .UseKestrel()

            ///This method configures the root directory for the application, 
            ///which is used for loading configuration files and delivering static content such as images, JavaScript, and CSS.
            .UseContentRoot(Directory.GetCurrentDirectory())

            ///This method is used to prepare the configuration data for the application, 
            ///as described in the “Configuring the Application” section later in this chapter.
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                if (env.IsDevelopment())
                {
                    var appAssembly =
                    Assembly.Load(new AssemblyName(env.ApplicationName));
                    if (appAssembly != null)
                    {
                        ///This method is used to store sensitive data outside of code files, 
                        ///as described at https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets.
                        ///This is a somewhat awkward feature, which I do not use in this book.
                        config.AddUserSecrets(appAssembly, optional: true);
                    }
                }
                config.AddEnvironmentVariables();
                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })

            ///This method is used to configure logging for the application, 
            ///as described in the “Configuring Logging” section later in this chapter.
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(
                hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            })

            ///This method enables integration with IIS and IIS Express.
            .UseIISIntegration()
            
            ///This method is used to configure dependency injection, 
            ///as described in the “Configuring Dependency Injection” section.
            .UseDefaultServiceProvider((context, options) =>
            {
                options.ValidateScopes =
                context.HostingEnvironment.IsDevelopment();
            })

            ///This method specifies the class that will be used to configure ASP.NET, 
            ///as described in the “Understanding the Startup Class” section.
            .UseStartup<Startup>();



        public static IWebHostBuilder BuildWebHost(string[] args)
        {
            return new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("logging"));
                logging.AddConsole();
                logging.AddDebug();
            })
            .UseIISIntegration()
            .UseDefaultServiceProvider((context, options) => {
                options.ValidateScopes =
                context.HostingEnvironment.IsDevelopment();
            })
            .UseStartup<Startup>();
            
        }
    }
}

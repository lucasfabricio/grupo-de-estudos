﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Classificados.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile("autofac.json");
                    config.AddJsonFile($"autofac.{env.EnvironmentName}.json", optional: true);
                    config.AddEnvironmentVariables();
                })
                //.UseSerilog((hostingContext, loggerConfiguration) =>
                //{
                //    loggerConfiguration.MinimumLevel.Debug()
                //        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                //        .Enrich.FromLogContext()
                //        .WriteTo.RollingFile(Path.Combine(hostingContext.HostingEnvironment.ContentRootPath, "logs/log-{Date}.log"));
                //})
                .ConfigureServices(services => services.AddAutofac());
                //.Build();
    }
}

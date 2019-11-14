using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureAppConfig_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var settings = config.Build();

                        config.AddAzureAppConfiguration(options =>
                        {
                            // Use ".Connect(...)" for connection string, or use ".ConnectWithManagedIdentity(...) for managed identity" 
                            options.Connect(settings["ConnectionStrings:AppConfig"])
                                   .Use(keyFilter: "WebDemo:*")
                                   .ConfigureRefresh((refreshOptions) =>
                                   {
                                       refreshOptions.Register(key: "WebDemo:Sentinel", label: LabelFilter.Null, refreshAll: true)
                                                     .SetCacheExpiration(TimeSpan.FromSeconds(10));
                                   });

                        });

                        settings = config.Build();

                    })
                    .UseStartup<Startup>();
                });
    }
}

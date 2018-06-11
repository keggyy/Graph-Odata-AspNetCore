using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Example.DAL;
using Example.DAL.Models;

namespace GraphQL.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //            BuildWebHost(args).Run();
            var host = new WebHostBuilder()
                          .UseKestrel()
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseIISIntegration()
                          .UseStartup<Startup>()
                          .UseSetting("detailedErrors", "true")
                          .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BookContext>();

                BooksInitializer.Initialize(context);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}

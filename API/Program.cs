using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Modyfiy the host builder
            var host = CreateHostBuilder(args).Build();
            // Adding a scope to the service
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

           try
           {
                // Creates a migration to the database after every new starup.
                var context = services.GetRequiredService<DataContext>();
                //await context.Database.MigrateAsync();
                await Seed.SeedData(context);

           }catch(Exception ex)
           {
                // If not success send an error to logger.
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error did accured during migration at the startup");
           }
            
           await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

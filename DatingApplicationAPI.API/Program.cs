using System;
using DatingApplicationAPI.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApplicationAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var sevices = scope.ServiceProvider;
                try
                {
                    var context = sevices.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                    Seed.SeedUsers(context);
                }
                catch(Exception ex)
                {
                    var logger = sevices.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error occured during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

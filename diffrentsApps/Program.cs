using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyClassLibrary2;

namespace DiffrentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); 
                    logging.AddConsole(); 
                    logging.SetMinimumLevel(LogLevel.Warning); 
                    logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning); 
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"),
                            sqlOptions => sqlOptions.EnableRetryOnFailure()));

                    services.AddTransient<App>();
                })
                .Build();

            
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            var app = host.Services.GetRequiredService<App>();
            app.RunMain();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using myClassLibrary2;
using System.IO;

namespace MyClassLibrary2
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Hämta anslutningssträngen från appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Ska vara rotmappen för diffrentsApps
                .AddJsonFile("appsettings.json") // Säkerställ att appsettings.json finns här
                .Build();

            // Lägg till debug-logg för att skriva ut den aktuella katalogen
            Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace myClassLibrary2
{
    public class Build
    {
        public ApplicationDbContext BuildDb()
        {
            try
            {
                // Läs konfiguration från appsettings.json
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Får rätt sökväg för appsettings.json
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var config = builder.Build();
                var connectionString = config.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Anslutningssträngen 'DefaultConnection' är inte konfigurerad.");
                }

                Console.WriteLine("Anslutningssträng laddad korrekt.");

                // Skapa en DbContextOptions instans med rätt anslutningssträng
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(connectionString)  // SQL Server som databas
                    .Options;

                // Skapa och returnera ApplicationDbContext med den korrekta anslutningen
                var dbContext = new ApplicationDbContext(options);
                Console.WriteLine("DbContext skapad.");
                return dbContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skapande av DbContext: {ex.Message}");
                throw; // Rethrow exception så att den kan fångas i applikationen om det behövs
            }
        }
    }
}

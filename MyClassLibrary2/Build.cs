using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MyClassLibrary2
{
    public class Build
    {
        public ApplicationDbContext BuildDb()
        {
            try
            {
                
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) 
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var config = builder.Build(); 
                var connectionString = config.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Anslutningssträngen 'DefaultConnection' är inte konfigurerad.");
                }

                Console.WriteLine("Anslutningssträng laddad korrekt.");

                
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(connectionString) 
                    .Options;

                
                var dbContext = new ApplicationDbContext(options, config); 
                Console.WriteLine("DbContext skapad.");
                return dbContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skapande av DbContext: {ex.Message}");
                throw;
            }
        }
    }
}

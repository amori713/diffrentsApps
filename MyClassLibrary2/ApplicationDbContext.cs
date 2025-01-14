using Microsoft.EntityFrameworkCore;
using MyClassLibrary2.Models; // Anpassa namespace efter din struktur

namespace myClassLibrary2
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<RockPaperScissors> RockPaperScissorsResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                // Lägg till eventuell initialiseringslogik här
                // Exempelvis kan du här initiera något i din databas om det behövs.
                Console.WriteLine("DbContext initialiserad.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid instansiering av ApplicationDbContext: {ex.Message}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                // Shape-discriminator för arv
                modelBuilder.Entity<Shape>().HasDiscriminator<string>("ShapeType")
                    .HasValue<Rectangle>("Rectangle")
                    .HasValue<Parallelogram>("Parallelogram")
                    .HasValue<Triangle>("Triangle")
                    .HasValue<Rhombus>("Rhombus");

                base.OnModelCreating(modelBuilder); // Kalla basklassens implementation
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid konfiguration av modell: {ex.Message}");
            }
        }
    }
}

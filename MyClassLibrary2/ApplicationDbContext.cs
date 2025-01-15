using Microsoft.EntityFrameworkCore;
using MyClassLibrary2.Models; 

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
                modelBuilder.Entity<Shape>().HasDiscriminator<string>("ShapeType")
                    .HasValue<Rectangle>("Rectangle")
                    .HasValue<Parallelogram>("Parallelogram")
                    .HasValue<Triangle>("Triangle")
                    .HasValue<Rhombus>("Rhombus");

                // Seed data for Shapes
                modelBuilder.Entity<Shape>().HasData(
                    new Rectangle { Id = 1, ShapeType = "Rectangle", Width = 5, Height = 10, Area = 50, Perimeter = 30, CalculatedOn = DateTime.Now },
                    new Parallelogram { Id = 2, ShapeType = "Parallelogram", Base = 4, Height = 7, SideLength = 5, Area = 28, Perimeter = 18, CalculatedOn = DateTime.Now },
                    new Triangle { Id = 3, ShapeType = "Triangle", Base = 3, Height = 6, Area = 9, Perimeter = 12, CalculatedOn = DateTime.Now },
                    new Rhombus { Id = 4, ShapeType = "Rhombus", SideLength = 6, Height = 8, Area = 48, Perimeter = 24, CalculatedOn = DateTime.Now }
                );

                // Seed data for Calculations
                modelBuilder.Entity<Calculation>().HasData(
                    new Calculation { Id = 1, Operand1 = 10, Operand2 = 5, Operator = "+", Result = 15, PerformedOn = DateTime.Now, ShapeId = 1 },
                    new Calculation { Id = 2, Operand1 = 20, Operand2 = 4, Operator = "/", Result = 5, PerformedOn = DateTime.Now, ShapeId = 2 },
                    new Calculation { Id = 3, Operand1 = 7, Operand2 = 3, Operator = "-", Result = 4, PerformedOn = DateTime.Now, ShapeId = 3 }
                );

                // Seed data for RockPaperScissors
                modelBuilder.Entity<RockPaperScissors>().HasData(
                    new RockPaperScissors { Id = 1, PlayerChoice = "sten", ComputerChoice = "sax", Result = "Vinst", PlayedOn = DateTime.Now, ShapeId = 1, CalculationId = 1 },
                    new RockPaperScissors { Id = 2, PlayerChoice = "påse", ComputerChoice = "sten", Result = "Vinst", PlayedOn = DateTime.Now, ShapeId = 2, CalculationId = 2 }
                );

                base.OnModelCreating(modelBuilder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid konfiguration av modell: {ex.Message}");
            }
        }

    }

}



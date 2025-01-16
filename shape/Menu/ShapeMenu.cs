using System;
using System.Linq;
using MyClassLibrary2.Models;
using Microsoft.EntityFrameworkCore;
using MyClassLibrary2;

namespace ShapeMenuNamespace
{
    public class ShapeMenu
    {
        private readonly ApplicationDbContext _dbContext;

        public ShapeMenu(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Shape Menu!");
                Console.WriteLine("1. Skapa ny form");
                Console.WriteLine("2. Visa alla former");
                Console.WriteLine("3. Avsluta");
                Console.Write("Ditt val: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            CreateShape();
                            break;
                        case "2":
                            DisplayShapes();
                            break;
                        case "3":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel inträffade i huvudmenyn: {ex.Message}");
                }
            }
        }

        private void CreateShape()
        {
            Console.Clear();
            Console.WriteLine("Vilken typ av form vill du skapa?");
            Console.WriteLine("1. Parallelogram");
            Console.WriteLine("2. Romb");
            Console.WriteLine("3. Rektangel");
            Console.WriteLine("4. Triangel");
            Console.Write("Ditt val: ");
            Shape newShape = null;

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        newShape = CreateParallelogram();
                        break;
                    case "2":
                        newShape = CreateRhombus();
                        break;
                    case "3":
                        newShape = CreateRectangle();
                        break;
                    case "4":
                        newShape = CreateTriangle();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        return;
                }

                if (newShape != null)
                {
                    newShape.CalculatedOn = DateTime.Now;
                    _dbContext.Shapes.Add(newShape);

                    try
                    {
                        _dbContext.SaveChanges();
                        Console.WriteLine("Formen har skapats och sparats.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fel vid sparande av ändringar: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när formen skapades: {ex.Message}");
            }
            Console.ReadKey();
        }

        private Shape CreateParallelogram()
        {
            try
            {
                Console.Write("Ange basen: ");
                double baseLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ange höjden: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ange sidlängden: ");
                double sideLength = Convert.ToDouble(Console.ReadLine());

                return new Parallelogram
                {
                    ShapeType = "Parallelogram",
                    Base = baseLength,
                    Height = height,
                    SideLength = sideLength,
                    Area = baseLength * height,
                    Perimeter = 2 * (baseLength + sideLength)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när parallelogrammet skapades: {ex.Message}");
                return null;
            }
        }

        private Shape CreateRhombus()
        {
            try
            {
                Console.Write("Ange sidlängden: ");
                double sideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ange höjden: ");
                double height = Convert.ToDouble(Console.ReadLine());

                return new Rhombus
                {
                    ShapeType = "Rhombus",
                    SideLength = sideLength,
                    Height = height,
                    Area = sideLength * height,
                    Perimeter = 4 * sideLength
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när romben skapades: {ex.Message}");
                return null;
            }
        }

        private Shape CreateRectangle()
        {
            try
            {
                Console.Write("Ange bredden: ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ange höjden: ");
                double height = Convert.ToDouble(Console.ReadLine());

                return new Rectangle
                {
                    ShapeType = "Rectangle",
                    Width = width,
                    Height = height,
                    Area = width * height,
                    Perimeter = 2 * (width + height)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när rektangeln skapades: {ex.Message}");
                return null;
            }
        }

        private Shape CreateTriangle()
        {
            try
            {
                Console.Write("Ange basen: ");
                double baseLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ange höjden: ");
                double height = Convert.ToDouble(Console.ReadLine());

                return new Triangle
                {
                    ShapeType = "Triangle",
                    Base = baseLength,
                    Height = height,
                    Area = (baseLength * height) / 2,
                    Perimeter = baseLength + 2 * height
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när triangeln skapades: {ex.Message}");
                return null;
            }
        }

        private void DisplayShapes()
        {
            try
            {
                var shapes = _dbContext.Shapes.ToList();
                Console.Clear();
                if (shapes.Any())
                {
                    Console.WriteLine("Lista över sparade former:");
                    foreach (var shape in shapes)
                    {
                        Console.WriteLine($"{shape.ShapeType}: Area = {shape.Area}, Omkrets = {shape.Perimeter}, Beräknad = {shape.CalculatedOn}");
                    }
                }
                else
                {
                    Console.WriteLine("Inga former hittades.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när former visades: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}

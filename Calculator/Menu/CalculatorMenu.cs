using System;
using System.Linq;
using MyClassLibrary2.Models;
using Microsoft.EntityFrameworkCore;
using myClassLibrary2;

namespace CalculatorMenuNamespace
{
    public class CalculatorMenu
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculatorMenu(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Miniräknaren!");
                Console.WriteLine("1. Utför en beräkning");
                Console.WriteLine("2. Visa beräkningshistorik");
                Console.WriteLine("3. Avsluta");
                Console.Write("Ditt val: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            PerformCalculation();
                            break;
                        case "2":
                            DisplayCalculationHistory();
                            break;
                        case "3":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel inträffade i huvudmenyn: {ex.Message}");
                }
            }
        }

        private void PerformCalculation()
        {
            try
            {
                Console.Write("Ange första talet: ");
                double operand1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ange operator (+, -, *, /): ");
                string operatorChoice = Console.ReadLine();

                Console.Write("Ange andra talet: ");
                double operand2 = Convert.ToDouble(Console.ReadLine());

                double result = operatorChoice switch
                {
                    "+" => operand1 + operand2,
                    "-" => operand1 - operand2,
                    "*" => operand1 * operand2,
                    "/" when operand2 != 0 => operand1 / operand2,
                    "/" => throw new DivideByZeroException("Division med noll är inte tillåtet."),
                    _ => throw new InvalidOperationException("Ogiltig operator.")
                };

                // Skapa en Shape om det inte finns en att använda
                var shape = _dbContext.Shapes.FirstOrDefault();  // Hämtar första Shape, eller null om ingen finns

                if (shape == null)
                {
                    // Om ingen Shape finns, skapa en ny
                    shape = new Shape
                    {
                        ShapeType = "Rektangel", // Exempel på form, kan ändras
                        Area = 20,               // Exempelvärde, ändra efter behov
                        Perimeter = 40,
                        CalculatedOn = DateTime.Now
                    };
                    _dbContext.Shapes.Add(shape);  // Lägg till Shape till databasen
                    _dbContext.SaveChanges();  // Spara för att få ett Id för Shape
                }

                // Skapa och koppla beräkningen till ShapeId
                var calculation = new Calculation
                {
                    Operand1 = operand1,
                    Operand2 = operand2,
                    Operator = operatorChoice,
                    Result = result,
                    PerformedOn = DateTime.Now,
                    ShapeId = shape.Id  // Koppla beräkningen till ShapeId
                };

                _dbContext.Calculations.Add(calculation);  // Lägg till beräkningen
                _dbContext.SaveChanges();  // Spara beräkningen

                Console.WriteLine($"Resultat: {result}");
                Console.WriteLine("Beräkningen har sparats.");

            }
            catch (FormatException)
            {
                Console.WriteLine("Felaktigt inmatningsformat. Vänligen ange giltiga tal.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade vid beräkning: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                }
            }
            Console.ReadKey();
        }


        private void DisplayCalculationHistory()
        {
            try
            {
                var history = _dbContext.Calculations.ToList();
                Console.Clear();
                if (history.Any())
                {
                    Console.WriteLine("Beräkningshistorik:");
                    foreach (var calc in history)
                    {
                        Console.WriteLine($"{calc.PerformedOn}: {calc.Operand1} {calc.Operator} {calc.Operand2} = {calc.Result}");
                    }
                }
                else
                {
                    Console.WriteLine("Ingen beräkningshistorik hittades.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när beräkningshistoriken visades: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}

// DiffrentsApp/App.cs
using CalculatorMenuNamespace;
using MyClassLibrary2;
using RPCMenuNamespace;
using ShapeMenuNamespace;
using System;

namespace DiffrentsApp
{
    public class App
    {
        private readonly ApplicationDbContext _dbContext;

        public App(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Console.WriteLine("DbContext har initialiserats.");
        }

        public void RunMain()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till App!");
                Console.WriteLine("1. Hantera Former");
                Console.WriteLine("2. Miniräknare");
                Console.WriteLine("3. Sten, Sax, Påse");
                Console.WriteLine("4. Avsluta");
                Console.Write("Ditt val: ");

                try
                {
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var shapeMenu = new ShapeMenu(_dbContext);
                            shapeMenu.MainMenu();
                            break;
                        case "2":
                            var calculatorMenu = new CalculatorMenu(_dbContext);
                            calculatorMenu.MainMenu();
                            break;
                        case "3":
                            var rpcMenu = new RPCMenu(_dbContext);
                            rpcMenu.MainMenu();
                            break;
                        case "4":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                }
            }
        }
    }
}

using System;
using System.Linq;
using MyClassLibrary2.Models;
using Microsoft.EntityFrameworkCore;
using myClassLibrary2;

namespace RPCMenuNamespace
{
    public class RPCMenu
    {
        private readonly ApplicationDbContext _dbContext;

        public RPCMenu(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MainMenu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Sten, Sax, Påse!");
                Console.WriteLine("1. Spela ett spel");
                Console.WriteLine("2. Visa spelhistorik");
                Console.WriteLine("3. Avsluta");
                Console.Write("Ditt val: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            PlayGame();
                            break;
                        case "2":
                            DisplayGameHistory();
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

        private void PlayGame()
        {
            try
            {
                Console.WriteLine("Välj Sten, Sax eller Påse:");
                string playerChoice = Console.ReadLine()?.ToLower();
                if (playerChoice != "sten" && playerChoice != "sax" && playerChoice != "påse")
                {
                    Console.WriteLine("Ogiltigt val.");
                    return;
                }

                string[] choices = { "sten", "sax", "påse" };
                Random rand = new Random();
                string computerChoice = choices[rand.Next(choices.Length)];

                string result = GetResult(playerChoice, computerChoice);
                Console.WriteLine($"Du valde: {playerChoice}, Datorn valde: {computerChoice}");
                Console.WriteLine($"Resultat: {result}");

                var game = new MyClassLibrary2.Models.RockPaperScissors
                {
                    PlayerChoice = playerChoice,
                    ComputerChoice = computerChoice,
                    Result = result,
                    PlayedOn = DateTime.Now
                };

                _dbContext.RockPaperScissorsResults.Add(game);

                try
                {
                    
                    _dbContext.SaveChanges();
                    Console.WriteLine("Spelet har sparats.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel vid sparande av spelet: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när spelet spelades: {ex.Message}");
            }
            Console.ReadKey();
        }

        private string GetResult(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
                return "Oavgjort";

            if ((playerChoice == "sten" && computerChoice == "sax") ||
                (playerChoice == "sax" && computerChoice == "påse") ||
                (playerChoice == "påse" && computerChoice == "sten"))
                return "Du vann";

            return "Du förlorade";
        }

        private void DisplayGameHistory()
        {
            try
            {
                var history = _dbContext.RockPaperScissorsResults.ToList();
                Console.Clear();
                if (history.Any())
                {
                    Console.WriteLine("Spelhistorik:");
                    foreach (var game in history)
                    {
                        Console.WriteLine($"{game.PlayedOn}: Du valde {game.PlayerChoice}, Datorn valde {game.ComputerChoice}. Resultat: {game.Result}");
                    }
                }
                else
                {
                    Console.WriteLine("Ingen spelhistorik hittades.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel inträffade när spelhistoriken visades: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}

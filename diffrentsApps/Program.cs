using System;
using MyClassLibrary2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShapeMenuNamespace;
using CalculatorMenuNamespace;
using RPCMenuNamespace;

namespace DiffrentsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                App app = new App();
                app.RunMain(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }
        }
    }
}

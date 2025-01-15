using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary2.Models
{
    public class Shape
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string ShapeType { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public DateTime CalculatedOn { get; set; }
        public List<Calculation> Calculations { get; set; }  
        public List<RockPaperScissors> RockPaperScissorsGames { get; set; }

    }

    public class Parallelogram : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double SideLength { get; set; }
    }

    public class Rhombus : Shape
    {
        public double SideLength { get; set; }
        public double Height { get; set; }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary2.Models
{
    public class RockPaperScissors
    {
        public int Id { get; set; }
        public string PlayerChoice { get; set; }
        public string ComputerChoice { get; set; }
        public string Result { get; set; }
        public DateTime PlayedOn { get; set; }
        public int? ShapeId { get; set; }  
        public Shape Shape { get; set; }

        public int? CalculationId { get; set; }  
        public Calculation Calculation { get; set; }
    }
}

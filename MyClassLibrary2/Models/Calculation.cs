using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary2.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public string Operator { get; set; }
        public double Result { get; set; }
        public DateTime PerformedOn { get; set; }
        public int ShapeId { get; set; }
        public Shape Shape { get; set; }

        public List<RockPaperScissors> RockPaperScissorsGames { get; set; }
    }
}

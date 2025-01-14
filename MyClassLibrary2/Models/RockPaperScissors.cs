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
    }
}

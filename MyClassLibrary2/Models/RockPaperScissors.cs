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

        public double WinPercentage { get; set; }

        
        public RockPaperScissors()
        {
            
        }
    }
}

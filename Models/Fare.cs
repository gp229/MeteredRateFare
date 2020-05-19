using System;

namespace MeteredRateFare.Models
{
    public class Fare
    {
        public int MinutesAbove6 { get; set; }
        public decimal MilesBelow6 { get; set; }
        public DateTime StartTime { get; set; }
    }
}
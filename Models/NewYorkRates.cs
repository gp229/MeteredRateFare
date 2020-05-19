using System;

namespace MeteredRateFare.Models
{
    public class NewYorkRates : IRates
    {
        public decimal InitialEntry => 3;
        public decimal BaseUnitRate => 0.35M;
        public decimal StateTaxSurcharge => 0.50M;
        public decimal NightSurcharge => 0.50M;
        public decimal PeakWeekdaySurcharge => 1;
        public TimeSpan NightStartHours => new TimeSpan(20, 0, 0);
        public TimeSpan NightEndHours => new TimeSpan(6, 0, 0);
        public TimeSpan PeakStartHours => new TimeSpan(16, 0, 0);
        public TimeSpan PeakEndHours => new TimeSpan(20, 0, 0);
    }
}
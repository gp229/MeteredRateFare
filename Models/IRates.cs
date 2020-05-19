using System;

namespace MeteredRateFare.Models
{
    public interface IRates
    {
        decimal InitialEntry { get; }
        decimal BaseUnitRate { get; }
        decimal StateTaxSurcharge { get; }
        decimal NightSurcharge { get; }
        decimal PeakWeekdaySurcharge { get; }
        TimeSpan NightStartHours { get; }
        TimeSpan NightEndHours { get; }
        TimeSpan PeakStartHours { get; }
        TimeSpan PeakEndHours { get; }
    }
}
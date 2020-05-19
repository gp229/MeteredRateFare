using System;

namespace MeteredRateFare.Models
{
    public static class FareManager
    {
        private const decimal DistanceUnitsOfMile = 0.2M;

        public static decimal CalculateFare(int minutesAbove6, decimal milesBelow6, DateTime startTime, IRates rates)
        {
            decimal fare = rates.InitialEntry + rates.StateTaxSurcharge;

            DateTime endTime = startTime.AddMinutes(minutesAbove6);
            if (DateTimeHelper.TimeIsInBetween(startTime, rates.NightStartHours, rates.NightEndHours))
            {
                fare += rates.NightSurcharge;
            }
            else if (DateTimeHelper.TimeIsInBetween(endTime, rates.NightStartHours, rates.NightEndHours) ||
                     DateTimeHelper.WillTimeBeReached(endTime, minutesAbove6, rates.NightStartHours))
            {
                fare += rates.NightSurcharge;
            }

            if (!startTime.IsWeekend() && DateTimeHelper.TimeIsInBetween(startTime, rates.PeakStartHours, rates.PeakEndHours))
            {
                fare += rates.PeakWeekdaySurcharge;
            }
            else if (!endTime.IsWeekend() &&
                     (DateTimeHelper.TimeIsInBetween(endTime, rates.PeakStartHours, rates.PeakEndHours) ||
                      DateTimeHelper.WillTimeBeReached(endTime, minutesAbove6, rates.PeakStartHours)))
            {
                fare += rates.PeakWeekdaySurcharge;
            }

            decimal distanceUnits = milesBelow6 / DistanceUnitsOfMile;
            fare += (distanceUnits + minutesAbove6) * rates.BaseUnitRate;
            return fare;
        }
    }
}

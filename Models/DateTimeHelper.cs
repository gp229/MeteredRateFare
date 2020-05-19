using System;

namespace MeteredRateFare.Models
{
    public static class DateTimeHelper
    {
        public static bool TimeIsInBetween(DateTime givenTime, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime <= endTime)
            {
                if (givenTime.TimeOfDay >= startTime && givenTime.TimeOfDay <= endTime)
                {
                    return true;
                }
            }
            else
            {
                if (givenTime.TimeOfDay >= startTime || givenTime.TimeOfDay <= endTime)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool WillTimeBeReached(DateTime givenTime, int minutes, TimeSpan timeToReach)
        {
            var timeUntilNight = timeToReach - givenTime.TimeOfDay;
            if (timeUntilNight.TotalMinutes < 0)
                timeUntilNight += new TimeSpan(24, 0, 0);
            return minutes > timeUntilNight.TotalMinutes;
        }

        public static bool IsWeekend(this DateTime time)
        {
            return time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
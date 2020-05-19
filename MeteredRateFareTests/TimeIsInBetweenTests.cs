using System;
using MeteredRateFare.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeteredRateFareTests
{
    [TestClass]
    public class TimeIsInBetweenTests
    {
        [TestMethod]
        public void TimeRangeIsSameDayAndTimeIsBetween()
        {
            DateTime time = new DateTime(1, 1, 1, 16, 0, 0);
            TimeSpan startTime = new TimeSpan(14, 0, 0);
            TimeSpan endTime = new TimeSpan(18, 0, 0);

            Assert.IsTrue(DateTimeHelper.TimeIsInBetween(time, startTime, endTime));
        }
        
        [TestMethod]
        public void TimeRangeIsDifferentDayAndTimeIsBetween()
        {
            DateTime time = new DateTime(1, 1, 1, 16, 0, 0);
            TimeSpan startTime = new TimeSpan(14, 0, 0);
            TimeSpan endTime = new TimeSpan(4, 0, 0);

            Assert.IsTrue(DateTimeHelper.TimeIsInBetween(time, startTime, endTime));
        }
        
        [TestMethod]
        public void TimeRangeIsSameDayAndTimeIsNotBetween()
        {
            DateTime time = new DateTime(1, 1, 1, 13, 0, 0);
            TimeSpan startTime = new TimeSpan(14, 0, 0);
            TimeSpan endTime = new TimeSpan(18, 0, 0);

            Assert.IsFalse(DateTimeHelper.TimeIsInBetween(time, startTime, endTime));
        }
        
        [TestMethod]
        public void TimeRangeIsDifferentDayAndTimeIsNotBetween()
        {
            DateTime time = new DateTime(1, 1, 1, 5, 0, 0);
            TimeSpan startTime = new TimeSpan(14, 0, 0);
            TimeSpan endTime = new TimeSpan(4, 0, 0);

            Assert.IsFalse(DateTimeHelper.TimeIsInBetween(time, startTime, endTime));
        }
    }
}
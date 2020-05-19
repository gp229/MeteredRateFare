using System;
using MeteredRateFare.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeteredRateFareTests
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void TimeIsReachedWithinSameDay()
        {
            var nightStartHours = new TimeSpan(20, 0, 0);
            DateTime dateTime = new DateTime(2020, 3, 3, 19, 0, 0);
            Assert.IsTrue(DateTimeHelper.WillTimeBeReached(dateTime, 70, nightStartHours));
        }
        
        [TestMethod]
        public void TimeIsReachedWithinNextDay()
        {
            var nightStartHours = new TimeSpan(2, 0, 0);
            DateTime dateTime = new DateTime(2020, 3, 3, 22, 0, 0);
            Assert.IsTrue(DateTimeHelper.WillTimeBeReached(dateTime, 300, nightStartHours));
        }
        
        [TestMethod]
        public void TimeIsNotReachedSameDay()
        {
            var nightStartHours = new TimeSpan(10, 0, 0);
            DateTime dateTime = new DateTime(2020, 3, 3, 3, 0, 0);
            Assert.IsFalse(DateTimeHelper.WillTimeBeReached(dateTime, 200, nightStartHours));
        }
        
        [TestMethod]
        public void TimeIsNotReachedNextDay()
        {
            var nightStartHours = new TimeSpan(2, 0, 0);
            DateTime dateTime = new DateTime(2020, 3, 3, 22, 0, 0);
            Assert.IsFalse(DateTimeHelper.WillTimeBeReached(dateTime, 120, nightStartHours));
        }
        
        [TestMethod]
        public void TimeIsAlreadyReached()
        {
            var nightStartHours = new TimeSpan(12, 0, 0);
            DateTime dateTime = new DateTime(2020, 3, 3, 12, 0, 0);
            Assert.IsTrue(DateTimeHelper.WillTimeBeReached(dateTime, 120, nightStartHours));
        }
    }
}
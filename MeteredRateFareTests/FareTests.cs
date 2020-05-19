using System;
using MeteredRateFare.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeteredRateFareTests
{
    [TestClass]
    public class FareTests
    {
        [TestMethod]
        public void TestNoHourSurcharges()
        {
            DateTime dateTime = new DateTime(2020, 3, 7, 19, 0, 0);
            decimal answer = FareManager.CalculateFare(1, 1M, dateTime, new NewYorkRates());
            Assert.AreEqual(5.60M,answer);
        }
        
        [TestMethod]
        public void TestNightAndPeakSurcharge()
        {
            DateTime dateTime = new DateTime(2020, 3, 3, 19, 59, 0);
            decimal answer = FareManager.CalculateFare(5, 1M, dateTime, new NewYorkRates());
            Assert.AreEqual(8.50M,answer);
        }
        
        [TestMethod]
        public void TestMilesFraction()
        {
            DateTime dateTime = new DateTime(2020, 3, 3, 19, 0, 0);
            decimal answer = FareManager.CalculateFare(1, 1.6M, dateTime, new NewYorkRates());
            Assert.AreEqual(7.65M,answer);
        }
    }
}
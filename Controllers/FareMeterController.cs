using System;
using System.Net;
using MeteredRateFare.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeteredRateFare.Controllers
{
    public class FareMeterController : Controller
    {
        [HttpPost]
        public ActionResult<decimal> GetFare([FromBody] Fare fare)
        {
            if (fare == null)
                return BadRequest();
            try
            {
                return FareManager.CalculateFare(fare.MinutesAbove6, fare.MilesBelow6, fare.StartTime, new NewYorkRates());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
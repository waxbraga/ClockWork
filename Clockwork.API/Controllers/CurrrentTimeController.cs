using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Linq;
using System.Collections.Generic;

namespace Clockwork.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/currenttime")]
    public class CurrentTimeController : Controller
    {
        // GET api/currenttime/new
        [HttpGet]
        [Route("new")]
        public IActionResult Get()
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime
            };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return Ok(returnVal);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var listQueries = new List<CurrentTimeQuery>();
            using (var db = new ClockworkContext())
            {
                listQueries = db.CurrentTimeQueries.ToList();
            }

            return Ok(listQueries);
        }

        [HttpGet]
        [Route("gettimezone")]
        public IActionResult GetTimezone(string timezone)
        {
            var serverTime = DateTime.Now;

            TimeZoneInfo selectedTimezone;
            try
            {
                selectedTimezone = TimeZoneInfo.FindSystemTimeZoneById(timezone);
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine($"Unable to retrieve the {timezone} time zone.");
                return BadRequest();
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine($"Unable to retrieve the {timezone} time zone.");
                return BadRequest();
            }

            Console.WriteLine("Local time zone: {0}\n", TimeZoneInfo.Local.DisplayName);
            DateTime convertedTime = TimeZoneInfo.ConvertTime(serverTime, selectedTimezone);

            var returnVal = new TimezoneQuery
            {
                ConvertedTime = convertedTime,
                Timezone = timezone,
                Time = serverTime
            };

            using (var db = new ClockworkContext())
            {
                db.TimezoneQueries.Add(returnVal);
                var count = db.SaveChanges();
            }

            return Ok(returnVal);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeServiceApp.Data;
using TimeServiceApp.Interfaces;
using TimeServiceApp.Services;

namespace TimeServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class TimeServiceController : ControllerBase
    {

        private readonly ILogger<TimeServiceController> _logger;
        private readonly ITimeService _timeService;

        public TimeServiceController(ILogger<TimeServiceController> logger, ITimeService timeService)
        {
            _logger = logger;
            _timeService = timeService; 
        }
        /// <summary>
        /// Get Time in 3 modes:
        /// 1.UTC - UTC +0;
        /// 2.Unix time - seconds passes from  01/01/1970 
        /// 3. UTC + TimeShift
        /// </summary>
        /// <param name="format">Time format for client. One of (UTC, TimeZoneUTC, Unix)</param>
        /// <param name="timeShift">Time shift (difference UTC), used for TimeZoneUTC </param>
        /// <returns>String with Date/Time for different formats</returns>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [HttpGet]
        [Route("gettime")]
        public IActionResult Get([FromQuery] TimeFormat format, [FromQuery] string timeShift)
        {
            _logger.LogInformation("Request recieved");
            var res = _timeService.GetTime(format, timeShift);
            return res == null ? BadRequest(res) : Ok(res);
        }
    }
}

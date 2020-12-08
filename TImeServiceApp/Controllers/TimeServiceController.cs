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
        /// Получение времени
        /// </summary>
        /// <param name="format">Формат времени, допустимые значения (UTC, TimeZoneUTC, Unix)</param>
        /// <param name="timezone">Временная зона (смещение) для параметра фомата TimeZoneUTC</param>
        /// <returns>Время в различных форматах</returns>
        [HttpGet]
        [Route("gettime")]
        public string Get([FromQuery]TimeFormat format, [FromQuery]string timezone)
        {
            return _timeService.GetTime(format, timezone);
        }
    }
}

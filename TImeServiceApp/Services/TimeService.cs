using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeServiceApp.Data;
using TimeServiceApp.Interfaces;

namespace TimeServiceApp.Services
{
    public class TimeService : ITimeService
    {
        public string GetTime(TimeFormat format, string timezone)
        {
            var time = DateTimeOffset.Now;
            switch (format)
            {
                case TimeFormat.UTC:
                    return time.ToUniversalTime().ToString();
                case TimeFormat.Unix:
                    return time.ToUnixTimeSeconds().ToString();
                case TimeFormat.TimeZoneUTC:
                    {
                        if (string.IsNullOrEmpty(timezone))
                            throw new ArgumentNullException(nameof(timezone));

                        if (timezone.StartsWith('+'))
                        {
                            timezone = timezone.Remove(0, 1);
                        }

                        try
                        {
                            var tz = TimeSpan.Parse(timezone);
                            return time.ToOffset(tz).ToString();
                        }
                        catch (Exception)
                        {

                            throw;
                        }


                    }

                default:
                    return null;
            }
        }
    }
}

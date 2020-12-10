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
        public string GetTime(TimeFormat format, string timeShift)
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
                        if (string.IsNullOrEmpty(timeShift))
                            throw new ArgumentNullException(nameof(timeShift));

                        if (timeShift.StartsWith('+'))
                        {
                            timeShift = timeShift.Remove(0, 1);
                        }

                        try
                        {
                            var tz = TimeSpan.Parse(timeShift);
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

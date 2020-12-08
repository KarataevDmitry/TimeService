using System.ComponentModel;

namespace TimeServiceApp.Data
{
    public enum TimeFormat
    {
        [Description("UTC")]
        UTC,
        [Description("UTC_TZ")]
        TimeZoneUTC, 
        [Description("Unix")]
        Unix
    }
}
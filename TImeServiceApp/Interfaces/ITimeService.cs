using TimeServiceApp.Data;

namespace TimeServiceApp.Interfaces
{
    public interface ITimeService
    {
        string GetTime(TimeFormat format, string timezone);
    }
}
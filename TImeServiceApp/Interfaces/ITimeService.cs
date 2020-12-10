using TimeServiceApp.Data;

namespace TimeServiceApp.Interfaces
{
    /// <summary>
    /// Interface for time service
    /// </summary>
    public interface ITimeService
    {
        string GetTime(TimeFormat format, string timezone);
    }
}
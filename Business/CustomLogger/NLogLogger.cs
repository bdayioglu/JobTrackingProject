using NLog;
using Business.Interfaces;

namespace Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("fileLogger");
            logger.Log(LogLevel.Error, message);
        }
    }
}

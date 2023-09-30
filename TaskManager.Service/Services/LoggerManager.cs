
using NLog;
using TaskManager.Domain.Contracts;

namespace TaskManager.Service.Services
{
    internal sealed class LoggerManager : ILoggerManager
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {}

        public void LogDebug(string message) => Logger.Debug(message);

        public void LogError(string message) => Logger.Error(message);

        public void LogInfo(string message) => Logger.Info(message);

        public void LogWarning(string message) => Logger.Warn(message);
    }

}

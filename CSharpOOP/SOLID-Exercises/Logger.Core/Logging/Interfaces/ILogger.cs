namespace Logger.Core.Logging.Interfaces
{
    public interface ILogger
    {
        public void Info(string DateAndTime, string logMessage);
        public void Warning(string DateAndTime, string logMessage);
        public void Error(string DateAndTime, string logMessage);
        public void Critical(string DateAndTime, string logMessage);
        public void Fatal(string DateAndTime, string logMessage);
    }
}

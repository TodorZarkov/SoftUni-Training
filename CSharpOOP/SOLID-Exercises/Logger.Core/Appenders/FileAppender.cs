namespace Logger.Core.Appenders
{
    using Enums;
    using IO;
    using Appenders.Interfaces;
    using Layouts.Interfaces;
    using Models.Interfaces;

    public class FileAppender : IAppender
    {
        private LogFile logFile;
        private int count;


        public FileAppender()
        {
            ReportLevel = ReportLevel.Info;
            count = 0;
        }
        public FileAppender(ILayout layout, LogFile logFile) : this()
        {
            Layout = layout;
            this.logFile = logFile;
        }



        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; private set; }

        public void Append(IMessage message)
        {
            if (this.ReportLevel > ReportLevel)
            {
                return;
            }
            string formatedLogMessage = Layout.Format(message);
            logFile.Write(formatedLogMessage);
            count++;
        }


        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {count}, File size {logFile.Size}";
        }
    }
}

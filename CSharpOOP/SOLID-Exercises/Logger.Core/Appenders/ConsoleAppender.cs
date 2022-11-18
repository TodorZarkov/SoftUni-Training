namespace Logger.Core.Appenders
{
    using Appenders.Interfaces;
    using Enums;
    using Logger.Core.Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;

    public class ConsoleAppender : IAppender
    {

        private int count;


        public ConsoleAppender()
        {
            ReportLevel = ReportLevel.Info;
            count = 0;
        }
        public ConsoleAppender(ILayout layout) : this()
        {
            Layout = layout;
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
            Console.WriteLine(formatedLogMessage);
            count++;
        }

        

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {count}";
        }
    }
}

namespace Logger.Core.Models
{
   
    using Enums;
    using Exceptions;
    using Interfaces;
    using Utilities;

    internal class Message : IMessage
    {
        private string? text;
        private string? dateTime;

        public Message(string text, string dateTime, ReportLevel reportLevel)
        {
            Text = text;
            DateTime = dateTime;
            ReportLevel = reportLevel;
        }

        public string Text
        {
            get { return text;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidTextMessageException();
                }
                text = value;
            }
        }

        public string DateTime
        {
            get { return dateTime; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidDateTimeException();
                }
                if (!Validation.IsDateTimeValidFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                dateTime = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}

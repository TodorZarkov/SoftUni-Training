
namespace Logger.Core.Models.Interfaces
{
    using Enums;

    public interface IMessage
    {
        public string Text { get; }

        public string DateTime { get; }

        public ReportLevel ReportLevel { get; }

    }
}

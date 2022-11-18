namespace Logger.Core.Appenders.Interfaces
{
    using Enums;
    using Layouts.Interfaces;
    using Models.Interfaces;

    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }


        public void Append(IMessage message);
    }
}

namespace Logger.Core.Layouts
{
    using Interfaces;
    using Models.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(IMessage message)
        {
            return $"{message.DateTime} - {message.ReportLevel} - {message.Text}";
        }
    }
}

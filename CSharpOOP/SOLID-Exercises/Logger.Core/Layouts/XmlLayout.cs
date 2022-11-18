namespace Logger.Core.Layouts
{
    using Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format(IMessage message)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<log>");
            sb.AppendLine($"    <date>{message.DateTime}</date>");
            sb.AppendLine($"    <level>{message.ReportLevel}</level>");
            sb.AppendLine($"    <message>{message.Text}</message>");
            sb.Append($"<log>");

            return sb.ToString();
        }
    }
}

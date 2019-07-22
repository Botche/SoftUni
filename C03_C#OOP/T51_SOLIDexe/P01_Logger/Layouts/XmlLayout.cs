using System.Text;

using P01_Logger.Contracts;

namespace P01_Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(IMessage message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{message.DateTime}</date>");
            sb.AppendLine($"    <level>{message.ReportLevel}</level>");
            sb.AppendLine($"    <message>{message.MessageText}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}

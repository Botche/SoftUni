using P01_Logger.Contracts;

namespace P01_Logger.Models
{
    public class Message : IMessage
    {
        public Message(string dateTime, ReportLevel reportLevel, string messageText)
        {
            DateTime = dateTime;
            ReportLevel = reportLevel;
            MessageText = messageText;
        }

        public string DateTime { get; }
        public ReportLevel ReportLevel { get; }
        public string MessageText { get; }
    }
}

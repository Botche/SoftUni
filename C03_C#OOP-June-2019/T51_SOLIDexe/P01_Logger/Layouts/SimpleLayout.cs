using P01_Logger.Contracts;

namespace P01_Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        private const string MessageFormat = "{0} - {1} - {2}";

        public string FormatMessage(IMessage message)
        {
            return string.Format(MessageFormat,
                message.DateTime,
                message.ReportLevel,
                message.MessageText);
        }
    }
}

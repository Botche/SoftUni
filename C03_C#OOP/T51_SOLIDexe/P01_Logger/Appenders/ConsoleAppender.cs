using System;
using P01_Logger.Models;
using P01_Logger.Contracts;

namespace P01_Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.INFO)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; set; }

        public void Append(IMessage message)
        {
            if (message.ReportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.Layout.FormatMessage(message));
                this.MessagesAppended++;
            }
        }
    }
}

using System;

using P01_Logger.Models;
using P01_Logger.Contracts;

namespace P01_Logger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.INFO)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.MessagesAppended = 0;
            this.File = new LogFile();
        }

        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; set; }
        public LogFile File { get; set; }

        public void Append(IMessage message)
        {
            if (this.File == null)
            {
                throw new InvalidOperationException("Log file cannot be null!");
            }

            this.File.Write(this.Layout.FormatMessage(message));
            this.MessagesAppended++;
        }
    }
}

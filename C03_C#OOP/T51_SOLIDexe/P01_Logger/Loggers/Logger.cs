using System.Collections.Generic;

using P01_Logger.Models;
using P01_Logger.Contracts;

namespace P01_Logger.Loggers
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string data, string message)
        {
            ReportLevel reportLevel = ReportLevel.INFO;
            this.Log(data, reportLevel, message);
        }
        public void Warning(string data, string message)
        {
            ReportLevel reportLevel = ReportLevel.WARNING;
            this.Log(data, reportLevel, message);
        }
        public void Error(string data,string message)
        {
            ReportLevel reportLevel = ReportLevel.ERROR;
            this.Log(data, reportLevel, message);
        }
        public void Critical(string data, string message)
        {
            ReportLevel reportLevel = ReportLevel.CRITICAL;
            this.Log(data, reportLevel, message);
        }
        public void Fatal(string data, string message)
        {
            ReportLevel reportLevel = ReportLevel.FATAL;
            this.Log(data, reportLevel, message);
        }

        private void Log(string dateTime,ReportLevel reportLevel, string messageText)
        {
            IMessage message = new Message(dateTime, reportLevel, messageText);

            foreach (var appender in appenders)
            {
                appender.Append(message);
            }
        }

    }
}

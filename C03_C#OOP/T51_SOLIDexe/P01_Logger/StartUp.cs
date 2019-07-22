using System;
using System.Text;
using System.Collections.Generic;

using P01_Logger.Models;
using P01_Logger.Layouts;
using P01_Logger.Loggers;
using P01_Logger.Appenders;
using P01_Logger.Contracts;

namespace P01_Logger
{
    class Program
    {
        static List<IAppender> Appenders = new List<IAppender>();
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = tokens[0];
                string layoutType = tokens[1];
                string reportLevel = string.Empty;

                var appender = InitializeAppender(appenderType, layoutType, reportLevel);

                if (tokens.Length == 3)
                {
                    reportLevel = tokens[2];
                    appender.ReportLevel = Enum.Parse<ReportLevel>(reportLevel);
                }

                Appenders.Add(appender);
            }

            Logger logger = new Logger(Appenders.ToArray());

            PrintMessages(logger);

            PrintLoggerInfo();
        }

        private static void PrintMessages(Logger logger)
        {
            string line = string.Empty;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] split = line.Split('|');

                string errorLevel = split[0].ToLower();
                string dateTime = split[1];
                string messageText = split[2];

                if (errorLevel == "info")
                {
                    logger.Info(dateTime, messageText);
                }
                else if (errorLevel == "warning")
                {
                    logger.Warning(dateTime, messageText);
                }
                else if (errorLevel == "error")
                {
                    logger.Error(dateTime, messageText);
                }
                else if (errorLevel == "critical")
                {
                    logger.Critical(dateTime, messageText);
                }
                else if (errorLevel == "fatal")
                {
                    logger.Fatal(dateTime, messageText);
                }
            }
        }

        private static void PrintLoggerInfo()
        {
            foreach (var appender in Appenders)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append($"Appender type: {appender.GetType().Name}, ");
                sb.Append($"Layout type: {appender.Layout.GetType().Name}, ");
                sb.Append($"Report level: {appender.ReportLevel}, ");
                sb.Append($"Messages appended: {appender.MessagesAppended}");
                if (appender is FileAppender fileAppender)
                {
                    sb.Append($"File size: {fileAppender.File.Size}");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }

        private static IAppender InitializeAppender(string appenderType, string layoutType, string reportLevel)
        {
            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                if (layoutType == "SimpleLayout")
                {
                    appender = new ConsoleAppender(new SimpleLayout());
                }
                else if (layoutType == "XmlLayout")
                {
                    appender = new ConsoleAppender(new XmlLayout());
                }
            }
            else if (appenderType == "FileAppender")
            {
                if (layoutType == "SimpleLayout")
                {
                    appender = new FileAppender(new SimpleLayout());
                }
                else if (layoutType == "XmlLayout")
                {
                    appender = new FileAppender(new XmlLayout());
                }
            }

            return appender;
        }
    }
}

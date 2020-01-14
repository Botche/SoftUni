using P01_Logger.Models;

namespace P01_Logger.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        int MessagesAppended { get; set; }

        void Append(IMessage message);
    }
}

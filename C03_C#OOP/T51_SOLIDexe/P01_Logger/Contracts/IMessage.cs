using P01_Logger.Models;

namespace P01_Logger.Contracts
{
    public interface IMessage
    {
        string DateTime { get; }
        ReportLevel ReportLevel { get; }
        string MessageText { get; }
    }
}

namespace P01_Logger.Contracts
{
    public interface ILogger
    {
        void Info(string data, string infoMessage);
        void Warning(string data, string infoMessage);
        void Error(string data, string errorMessage);
        void Critical(string data, string criticalMessage);
        void Fatal(string data, string fatalMessage);
    }
}

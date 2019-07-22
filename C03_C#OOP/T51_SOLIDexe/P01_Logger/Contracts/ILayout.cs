namespace P01_Logger.Contracts
{
    public interface ILayout
    {
        string FormatMessage(IMessage message);
    }
}

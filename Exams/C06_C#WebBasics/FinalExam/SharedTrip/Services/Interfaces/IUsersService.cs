namespace SharedTrip.Services.Interfaces
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool IsEmailUsed(string email);

        bool IsUsernameUsed(string username);

        string LogUser(string username, string password);
    }
}

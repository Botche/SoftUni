namespace SULS.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsEmailUsed(string email);

        bool IsUsernameUsed(string username);

        string GetUsernameById(string userId);
    }
}

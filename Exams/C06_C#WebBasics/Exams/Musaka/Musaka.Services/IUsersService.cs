namespace Musaka.Services
{
    public interface IUsersService
    {
        string LoginUser(string username, string password);

        bool CheckIfEmailIsUsed(string email);

        bool CheckIfUsernameIsUsed(string username);

        string RegisterUser(string username, string email, string password);
    }
}

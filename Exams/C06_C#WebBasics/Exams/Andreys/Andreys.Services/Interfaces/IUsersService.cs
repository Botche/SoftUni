using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services.Interfaces
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool IsEmailUsed(string email);

        bool IsUsernameUsed(string username);

        string LogUser(string username, string password);
    }
}

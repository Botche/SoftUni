using System;
using System.Net.Mail;

using SIS.HTTP;
using SIS.MvcFramework;

using SULS.App.ViewModels.Users;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (username.Length < 5 || username.Length > 20)
            {
                return Error("Username must be between 5 and 20 symbols.");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return Error("Password must be between 6 and 20 symbols.");
            }

            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return Error("There is no user with this combination from username and password.");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(InputUserViewModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return Error("Username must be between 5 and 20 symbols.");
            }

            if (!IsValid(input.Email))
            {
                return this.Error("Invalid email!");
            }

            if (input.Password.Length < 6
                || input.Password.Length > 20
                || input.ConfirmPassword.Length < 6
                || input.ConfirmPassword.Length > 20)
            {
                return Error("Password must be between 6 and 20 symbols.");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (this.usersService.IsUsernameUsed(input.Username))
            {
                return this.Error("Username already used!");
            }

            if (this.usersService.IsEmailUsed(input.Email))
            {
                return this.Error("Email already used!");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
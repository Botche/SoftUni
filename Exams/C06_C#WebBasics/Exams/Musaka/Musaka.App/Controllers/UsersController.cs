using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Musaka.App.ViewModels;
using Musaka.Services;
using SIS.HTTP;
using SIS.MvcFramework;

namespace Musaka.App.Controllers
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
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (username.Length < 5 || username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 symbols.");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 symbols.");
            }

            var userId = this.usersService.LoginUser(username,password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(InputUserRegisterViewModel input)
        {
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 symbols.");
            }

            if (this.IsValidEmail(input.Email))
            {
                return this.Error("Email is not valid.");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20
                || input.ConfirmPassword.Length < 6 || input.ConfirmPassword.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 symbols.");
            }

            if (input.Password == input.ConfirmPassword)
            {
                return this.Error("Passwords must be the same.");
            }

            if (this.usersService.CheckIfUsernameIsUsed(input.Username))
            {
                return this.Error("This username is already used.");
            }

            if (this.usersService.CheckIfEmailIsUsed(input.Email))
            {
                return this.Error("This email is already used.");
            }

            var userId = this.usersService.RegisterUser(input.Username, input.Email, input.Password);

            if (userId == null)
            {
                this.Redirect("/Users/Register");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (IsUserLoggedIn())
            {
                this.SignOut();
            }

            return this.Redirect("/");
        }

        private bool IsValidEmail(string emailaddress)
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
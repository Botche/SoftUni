using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Musaka.Data;
using Musaka.Models;

namespace Musaka.Services
{
    public class UsersService : IUsersService
    {
        private readonly MusakaDbContext db;

        public UsersService(MusakaDbContext db)
        {
            this.db = db;
        }

        public bool CheckIfEmailIsUsed(string email)
            => this.db.Users
            .Any(user => user.Email == email);

        public bool CheckIfUsernameIsUsed(string username)
            => this.db.Users
            .Any(user => user.Username == username);

        public string LoginUser(string username, string password)
            => this.db.Users
            .Where(user => (user.Username == username || user.Email == username) && user.Password == this.Hash(password))
            .Select(user => user.Id)
            .FirstOrDefault();

        public string RegisterUser(string username, string email, string password)
        {
            var hashedPassword = this.Hash(password);

            var user = new User()
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        private string Hash(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
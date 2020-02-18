using System.Linq;
using System.Security.Cryptography;
using System.Text;

using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class UsersService : IUsersService
    {
        private readonly SULSContext db;

        public UsersService(SULSContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var hashedPassword = this.Hash(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);

            var userId = this.db.Users
                .Where(user => (user.Username == username || user.Email == username) 
                                && user.Password == passwordHash)
                .Select(user => user.Id)
                .FirstOrDefault();

            return userId;
        }

        public string GetUsernameById(string id)
            => db.Users
                .Where(user => user.Id == id)
                .Select(user => user.Username)
                .FirstOrDefault();

        public bool IsEmailUsed(string email)
            => db.Users.Any(user => user.Email == email);

        public bool IsUsernameUsed(string username)
            => db.Users.Any(user => user.Username == username);

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

using System.Linq;
using System.Security.Cryptography;
using System.Text;

using SharedTrip.Models;
using SharedTrip.Services.Interfaces;

namespace SharedTrip.Services
{
    public class UsersService :IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Register(string username, string email, string password)
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

        public bool IsEmailUsed(string email)
            => db.Users.Any(user => user.Email == email);

        public bool IsUsernameUsed(string username)
            => db.Users.Any(user => user.Username == username);

        public string LogUser(string username, string password)
            => this.db.Users
            .Where(user => (user.Username.ToLower() == username.ToLower() 
                            || user.Email.ToLower() == username.ToLower())
                && user.Password == this.Hash(password))
            .Select(user => user.Id)
            .FirstOrDefault();

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string fullName, string email, int age, ICollection<Card> cards)
            :base()
        {
            this.Username = username;
            this.FullName = fullName;
            this.Email = email;
            this.Age = age;
            this.Cards = cards;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3,103)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; } = new HashSet<Card>();
    }
}

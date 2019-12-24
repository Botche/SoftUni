using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enum;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
        }

        public Card(string number, string cvc, CardType type)
            :base()
        {
            this.Number = number;
            this.Cvc = cvc;
            this.Type = type;
        }

        public int Id { get; set; }

        [RegularExpression(@"\d{4} \d{4} \d{4} \d{4}")]
        public string Number { get; set; }

        [RegularExpression(@"\d{3}")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Purchase> Purchases{ get; set; }
    }
}

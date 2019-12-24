using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enum;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        public Purchase()
        {
        }

        public Purchase(Game game, PurchaseType type, Card card, string productKey, DateTime date)
            :base()
        {
            this.Game = game;
            this.Type = type;
            this.Card = card;
            this.ProductKey = productKey;
            this.Date = date;
        }

        public int Id { get; set; }

        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"^[\dA-Z]{4}-[\dA-Z]{4}-[\dA-Z]{4}$")]
        public string ProductKey { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }
        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}

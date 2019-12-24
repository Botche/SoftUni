using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
	public class Game
    {
        public Game()
        {
        }

        public Game(string name, decimal price, DateTime releaseDate, Developer developer, Genre genre, ICollection<GameTag> gameTags)
            :base()
        {
            this.Name = name;
            this.Price = price;
            this.ReleaseDate = releaseDate;
            this.Developer = developer;
            this.Genre = genre;
            this.GameTags = gameTags;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        public ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public int Id { get; set; }

        [MaxLength(20), MinLength(3)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20), MinLength(3)]
        [Required]
        public string LastName { get; set; }

        [Range(18,70)]
        [Required]
        public int Age { get; set; }

        [MinLength(0)]
        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
}

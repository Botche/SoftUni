﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class GameDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Developer { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}

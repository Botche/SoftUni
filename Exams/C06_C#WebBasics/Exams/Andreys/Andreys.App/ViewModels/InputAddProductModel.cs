using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andreys.App.ViewModels
{
    public class InputAddProductModel
    {
        [Required]
        [MinLength(4), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Price { get; set; }
    }
}

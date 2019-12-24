using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumDto
    {
        [MaxLength(40), MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}

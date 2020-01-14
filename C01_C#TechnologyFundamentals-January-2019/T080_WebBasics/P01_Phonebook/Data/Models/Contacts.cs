using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class Contacts
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}

using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class DataAccess
    {
        public static List<Contacts> Contacts { get; set; } = new List<Contacts>();
    }
}

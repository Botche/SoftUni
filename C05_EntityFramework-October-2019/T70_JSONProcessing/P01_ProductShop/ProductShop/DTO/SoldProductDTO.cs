using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO
{
    class SoldProductDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<SoldProduct> SoldProducts { get; set; } = new List<SoldProduct>();
    }
}

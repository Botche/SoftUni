using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTO
{
    class SoldProductsDTO
    {
        public int Count { get; set; }

        public ICollection<ProductSold> Products { get; set; }
    }
}

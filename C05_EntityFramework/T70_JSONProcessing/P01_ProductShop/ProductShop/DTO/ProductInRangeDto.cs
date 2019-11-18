using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTO
{
    class ProductInRangeDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "seller")]
        public string Seller { get; set; }
    }
}

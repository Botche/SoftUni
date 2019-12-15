using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType(TypeName = "Product")]
    public class ProductInRangeDTO
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "buyer")]
        public string Buyer { get; set; }
    }
}

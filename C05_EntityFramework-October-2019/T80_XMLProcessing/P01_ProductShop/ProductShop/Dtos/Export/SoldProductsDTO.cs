using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType(TypeName = "SoldProducts")]
    public class SoldProductsDTO
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlArray(ElementName = "products")]
        public SoldProductDTO[] SoldProducts { get; set; }
    }
}

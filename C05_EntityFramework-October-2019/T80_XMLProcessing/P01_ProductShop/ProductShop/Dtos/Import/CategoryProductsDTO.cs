using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType(TypeName = "CategoryProduct")]
    public class CategoryProductsDTO
    {
        public int? CategoryId { get; set; }

        public int? ProductId { get; set; }
    }
}

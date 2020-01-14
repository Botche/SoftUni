using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType(TypeName = "Sale")]
    public class SaleDTO
    {
        [XmlElement(ElementName = "carId")]
        public int CarId { get; set; }

        [XmlElement(ElementName = "customeId")]
        public int CustomerId { get; set; }

        [XmlElement(ElementName = "discount")]
        public int Discount { get; set; }
    }
}

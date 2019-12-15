using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType(TypeName = "Customer")]
    public class CustomerDTO
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement(ElementName = "isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

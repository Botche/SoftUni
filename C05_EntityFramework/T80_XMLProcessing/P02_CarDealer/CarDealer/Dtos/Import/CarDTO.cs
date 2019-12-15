using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType(TypeName = "Car")]
    public class CarDTO
    {
        [XmlElement(ElementName = "make")]
        public string Make { get; set; }

        [XmlElement(ElementName = "model")]
        public string Model { get; set; }

        [XmlElement(ElementName = "TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlElement(ElementName = "parts")]
        public PartsIdDTO Parts { get; set; }
    }
}

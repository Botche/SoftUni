using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot(ElementName = "parts")]
    public class PartIdDTO
    {
        [XmlAttribute(AttributeName = "id")]
        public int PartId { get; set; }
    }
}

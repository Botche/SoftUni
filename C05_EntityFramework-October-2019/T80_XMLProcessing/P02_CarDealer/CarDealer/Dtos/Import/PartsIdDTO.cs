using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot(ElementName = "parts")]
    public class PartsIdDTO
    {
        [XmlElement(ElementName = "partId")]
        public PartIdDTO[] PartsId { get; set; }
    }
}

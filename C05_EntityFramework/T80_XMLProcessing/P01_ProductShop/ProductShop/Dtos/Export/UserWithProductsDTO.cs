﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType(TypeName = "User")]
    public class UserWithProductsDTO
    {
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "age")]
        public int? Age { get; set; }

        [XmlElement(ElementName = "SoldProducts")]
        public SoldProductsDTO SoldProducts { get; set; }
    }
}

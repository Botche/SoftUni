using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    class CarWithPartsDTO
    {
        [JsonProperty(PropertyName = "car")]
        public CarDTO Car { get; set; }

        [JsonProperty(PropertyName = "parts")]
        public ICollection<PartDTO> Parts { get; set; }
    }
}

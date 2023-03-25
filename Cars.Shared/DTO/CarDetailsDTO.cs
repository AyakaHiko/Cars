using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars.Shared.DTO
{
    public class CarDetailsDto : CarDto
    {
        [Display(Name = "Manufacturer Name")]
        [JsonPropertyOrder(10)]
        public string? ManufacturerName { get; set; } = default!;
        [Display(Name = "Manufacturer Country")]
        [JsonPropertyOrder(11)]
        public string? ManufacturerCountry { get; set; } = default!;
    }
}

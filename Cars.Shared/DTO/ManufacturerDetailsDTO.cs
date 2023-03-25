using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cars.Shared.DTO
{
    public class ManufacturerDetailsDto : ManufacturerDto
    {
        [JsonPropertyOrder(10)]
        public IEnumerable<CarDto>? Cars { get; set; }

    }
}

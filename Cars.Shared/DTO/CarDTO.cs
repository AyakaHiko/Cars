using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Shared.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Mark { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; } = default!;
        public int? ManufacturerId { get; set; }
        
    }
}

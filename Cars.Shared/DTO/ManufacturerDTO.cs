using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars.Shared.DTO
{
    public class ManufacturerDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; } = default!;

        [Display(Name = "Manufacturer Country")]
        public string? Country { get; set; } = default!;
    }
}

using Repositories.Interfaces;

namespace Cars.API.Data.Entities
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string Mark { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; } = default!;

        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; } = default!;
    }
}

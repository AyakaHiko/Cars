using Cars.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        { }
        public DbSet<Car?> Cars => Set<Car>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    }
}

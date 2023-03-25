using Cars.API.Data.Entities;

namespace Cars.API.Data
{
    public class Initializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            CarContext context = services.GetRequiredService<CarContext>();
            //await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            if (context.Cars.Any())
            {
                return;
            }
            var toyota = new Manufacturer { Name = "Toyota", Country = "Japan" };
            var honda = new Manufacturer { Name = "Honda", Country = "Japan" };
            var ford = new Manufacturer { Name = "Ford", Country = "United States" };
            var chevrolet = new Manufacturer { Name = "Chevrolet", Country = "United States" };

            var cars = new List<Car>
            {
                new() { Mark = "Toyota", Model = "Camry", Year = 2022, Price = 25000, Color = "Red", Manufacturer = toyota },
                new() { Mark = "Honda", Model = "Civic", Year = 2023, Price = 20000, Color = "Blue", Manufacturer = honda },
                new() { Mark = "Ford", Model = "Mustang", Year = 2022, Price = 35000, Color = "Black", Manufacturer = ford },
                new() { Mark = "Chevrolet", Model = "Camaro", Year = 2023, Price = 40000, Color = "Yellow", Manufacturer = chevrolet }
            };

            await context.AddRangeAsync(cars);
            await context.SaveChangesAsync();
        }
    }
}

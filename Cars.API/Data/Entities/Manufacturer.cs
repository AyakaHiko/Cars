using Repositories.Interfaces;

namespace Cars.API.Data.Entities;

public class Manufacturer:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Country { get; set; } = default!;
    public List<Car>? Cars { get; set; }
}
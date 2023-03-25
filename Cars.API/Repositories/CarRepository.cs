using Cars.API.Data;
using Cars.API.Data.Entities;
using Cars.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Repositories;

public class CarRepository : Repository<Car>
{
    protected override CarContext _context { get; }

    public CarRepository(CarContext context)
    {
        _context = context;
        _set = context.Cars;
    }


    public override async Task<IEnumerable<Car?>> GetDetails()
    {
        var entities = await _set.ToListAsync();
        foreach (var entity in entities)
        {
            await _context.Manufacturers
                .Where(m => m.Id == entity.ManufacturerId)
                .LoadAsync();
        }
        return entities;
    }
}
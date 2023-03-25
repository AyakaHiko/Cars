using Cars.API.Data;
using Cars.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

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

    public override async Task<Car?> GetDetails(int id)
    {
        var entity = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == id);

        if (entity is null)
        {
            return null;
        }

        await _context.Manufacturers
            .Where(c => c.Id == entity.ManufacturerId)
            .LoadAsync();

        return entity;
    }
}
using Cars.API.Data;
using Cars.API.Data.Entities;
using Cars.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Repositories
{
    public class ManufacturerRepository : Repository<Manufacturer>
    {
        protected override CarContext _context { get; }

        public ManufacturerRepository(CarContext context)
        {
            _context = context;
        }
        
        public override async Task<IEnumerable<Manufacturer?>> GetDetails()
        {
            var entities = await _context.Manufacturers.ToListAsync();

            foreach (var entity in entities)
            {
                await _context.Cars
                    .Where(c => c.ManufacturerId == entity.Id)
                    .LoadAsync();
            }

            return entities;
        }
        

        public override async Task<Manufacturer?> GetDetails(int id)
        {
            var entity = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
                return null;
            await _context.Cars
                .Where(c => c.ManufacturerId == entity.Id)
                .LoadAsync();
            return entity;
        }
        

    }
}

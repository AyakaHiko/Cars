using Microsoft.EntityFrameworkCore;

namespace Repositories;

public abstract class Repository<T> : IRepository<T> where T : class, IEntity
{
    protected DbSet<T?> _set;
    protected abstract DbContext _context { get; }

        
    public async Task<IEnumerable<T?>> Get()
    {
        return await _set.ToListAsync();
    }

    public abstract Task<IEnumerable<T?>> GetDetails();

    public async Task<T?> Get(int id)
    {
        return await _set.FirstOrDefaultAsync(c => c!.Id == id);
    }

    public abstract Task<T?> GetDetails(int id);

    public async Task<T?> Post(T entity)
    {
        var added = await _set.AddAsync(entity);
        await _context.SaveChangesAsync();

        return added.Entity;
    }

    public async Task<T?> Put(T entity)
    {
        var updated = _set.Update(entity);
        await _context.SaveChangesAsync();
        return updated.Entity;
    }

    public async Task<T?> Delete(T entity)
    {
        var deleted = _set.Remove(entity);
        await _context.SaveChangesAsync();
        return deleted.Entity;
    }

    public bool IsExists(int id)
    {
        return _set.Any(c => c.Id == id);
    }
}
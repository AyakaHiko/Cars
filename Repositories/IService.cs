
namespace Repositories;

public interface IService<T,TD>
{
    Task<IEnumerable<T?>> Get();
    Task<IEnumerable<TD?>> GetDetails();
    Task<T?> Get(int id);
    Task<TD?> GetDetails(int id);
    Task<T?> Post(T entity);
    Task<T?> Put(T entity);
    Task<T?> Delete(int id);
    bool IsExists(int id);
}
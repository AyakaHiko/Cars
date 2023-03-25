namespace Cars.API.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T?>> Get();
        Task<IEnumerable<T?>> GetDetails();
        Task<T?> Get(int id);
        Task<T?> GetDetails(int id);
        Task<T?> Post(T entity);
        Task<T?> Put(T entity);
        Task<T?> Delete(T entity);
        bool IsExists(int id);
    }
}
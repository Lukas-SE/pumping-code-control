using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>?> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
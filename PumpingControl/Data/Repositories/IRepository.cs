namespace PumpingControl.Data.Repositories;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid id, params string[] include);
    Task<List<T>?> GetAllAsync(params string[] include);
    Task AddAsync(T request);
    Task UpdateAsync(T request);
    Task DeleteAsync(T request);
}
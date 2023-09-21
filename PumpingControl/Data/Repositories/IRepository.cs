using PumpingControl.Application.Common.Enums;

namespace PumpingControl.Data.Repositories;

public interface IRepository<T>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>?> GetAllAsync();
    Task AddAsync(T request);
    Task UpdateAsync(T request);
    Task DeleteAsync(T request);
}
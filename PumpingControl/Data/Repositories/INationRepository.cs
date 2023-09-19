using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public interface INationRepository
{
    Task<Nation?> GetByIdAsync(Guid id);
    Task AddAsync(Nation player);
    Task UpdateAsync(Nation player);
    Task DeleteAsync(Nation player);
    Task<List<Nation>?> GetAllAsync();
    Task<Nation?> GetByNameAsync(string name);
}
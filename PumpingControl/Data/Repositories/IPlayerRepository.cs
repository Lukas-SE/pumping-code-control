using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public interface IPlayerRepository
{
    Task<Player?> GetByIdAsync(Guid id);
    Task AddAsync(Player player);
    Task UpdateAsync(Player player);
    Task DeleteAsync(Player player);
    Task<List<Player>?> GetAllAsync();
    Task<Player?> GetByEmailAsync(string email);
}
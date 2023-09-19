using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<Player> _dbSet;

    public PlayerRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<Player>();
    }

    public async Task<Player?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Player player)
    {
        await _dbSet.AddAsync(player);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Player player)
    {
        _dbSet.Update(player);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Player player)
    {
        _dbSet.Remove(player);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task<List<Player>?> GetAllAsync()
        => await (_applicationContext.Players ?? throw new InvalidOperationException()).ToListAsync();

    public async Task<Player?> GetByEmailAsync(string email)
        => await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Email == email);
}
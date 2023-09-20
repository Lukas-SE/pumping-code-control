using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;

namespace PumpingControl.Data.Repositories;

public abstract class Repository<T> : IRepository<T>
    where T : class
{
    protected readonly ApplicationContext _applicationContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T player)
    {
        await _dbSet.AddAsync(player);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T player)
    {
        _dbSet.Update(player);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T player)
    {
        _dbSet.Remove(player);
        await _applicationContext.SaveChangesAsync();
    }
}
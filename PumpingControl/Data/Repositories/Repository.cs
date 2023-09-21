using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public abstract class Repository<T> : IRepository<T>
    where T : Entity
{
    protected readonly ApplicationContext _applicationContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, params string[] include)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        if(include.Any())
            foreach(var item in include) query = query.Include(item);
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<T>?> GetAllAsync(params string[] include)
    {
        IQueryable<T> query = _dbSet.AsQueryable();
        if(include.Any())
            foreach(var item in include) query = query.Include(item);
        return await query.ToListAsync();
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
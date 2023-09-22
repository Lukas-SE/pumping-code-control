using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public abstract class Repository<T> : IRepository<T>
    where T : Entity
{
    protected readonly ApplicationContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationContext applicationContext)
    {
        _dbContext = applicationContext;
        _dbSet = _dbContext.Set<T>();
    }

    private IQueryable<T> IncludeNavigations()
    {
        var query = _dbSet.AsQueryable();

        var navigations = _dbContext.Model.FindEntityType(typeof(T))!
            .GetNavigations()
            .ToList();

        foreach (var item in navigations) query = query.Include(item.Name);

        return query;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var query = IncludeNavigations();

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<T>?> GetAllAsync()
    {
        var query = IncludeNavigations();

        return await query.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
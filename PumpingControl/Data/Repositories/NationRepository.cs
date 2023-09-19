using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public class NationRepository : INationRepository
{
    private readonly ApplicationContext _applicationContext;
    private readonly DbSet<Nation> _dbSet;

    public NationRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
        _dbSet = _applicationContext.Set<Nation>();
    }

    public async Task<Nation?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Nation nation)
    {
        await _dbSet.AddAsync(nation);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Nation nation)
    {
        _dbSet.Update(nation);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Nation nation)
    {
        _dbSet.Remove(nation);
        await _applicationContext.SaveChangesAsync();
    }

    public async Task<List<Nation>?> GetAllAsync()
    {
        return await (_applicationContext.Nations ?? throw new InvalidOperationException()).ToListAsync();
    }

    public async Task<Nation?> GetByNameAsync(string name)
        => await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Name == name);
}
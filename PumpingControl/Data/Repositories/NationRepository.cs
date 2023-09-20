using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public class NationRepository : Repository<Nation>, INationRepository
{
    public NationRepository(ApplicationContext applicationContext)
        :base(applicationContext)
    {
    }

    public async Task<Nation?> GetByNameAsync(string name)
    {
        return await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Name == name);
    }
}
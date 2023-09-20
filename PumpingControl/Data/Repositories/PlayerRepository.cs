using Microsoft.EntityFrameworkCore;
using PumpingControl.Data.Core;
using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    public PlayerRepository(ApplicationContext applicationContext)
        :base(applicationContext)
    {
    }

    public async Task<Player?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .AsQueryable()
            .FirstOrDefaultAsync(a => a.Email == email);
    }
}
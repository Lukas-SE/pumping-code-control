using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public interface IPlayerRepository: IRepository<Player>
{
    Task<Player?> GetByEmailAsync(string email);
}
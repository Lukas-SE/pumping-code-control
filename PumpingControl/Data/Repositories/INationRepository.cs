using PumpingControl.Domain;

namespace PumpingControl.Data.Repositories;

public interface INationRepository: IRepository<Nation>
{
    Task<Nation?> GetByNameAsync(string name);
}
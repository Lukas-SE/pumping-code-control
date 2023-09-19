using Microsoft.EntityFrameworkCore;
using PumpingControl.Domain;

namespace PumpingControl.Data.Core;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Player>? Players { get; set; }
    public DbSet<Nation>? Nations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationEntrypoint).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
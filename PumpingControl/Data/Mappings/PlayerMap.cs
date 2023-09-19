using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PumpingControl.Domain;

namespace PumpingControl.Data.Mappings;

public class PlayerMap : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("Id");

        builder.Property(c => c.Name)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(c => c.Email)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(c => c.BusinessUnit)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(c => c.Balance)
            .HasColumnType("decimal(8,2)");

        builder.ToTable("Players");
    }
}
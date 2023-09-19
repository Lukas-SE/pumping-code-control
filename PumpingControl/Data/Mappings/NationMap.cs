using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PumpingControl.Domain;

namespace PumpingControl.Data.Mappings;

public class NationMap : IEntityTypeConfiguration<Nation>
{
    public void Configure(EntityTypeBuilder<Nation> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("Id");

        builder.Property(c => c.Name)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder
            .HasMany(f => f.Players)
            .WithOne(b => b.Nation);

        builder.ToTable("Nations");
    }
}
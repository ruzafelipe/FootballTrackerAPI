using FootballTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTracker.Infrastructure.Persistence.Configurations;

public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
{
    public void Configure(EntityTypeBuilder<Stadium> builder)
    {
        builder.ToTable("Stadium");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.State)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.OpenedDate)
            .IsRequired();

        builder.Property(s => s.Capacity)
            .IsRequired();

        builder.Property(s => s.PhotoUrl)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Property(s => s.IsActive)
            .IsRequired();

        builder.Property(s => s.CreatedAt)
            .IsRequired();

        builder.Property(s => s.UpdatedAt)
            .IsRequired(false);

        //OPCIONAL: índices para otimizar consultas (se necessário)
        builder.HasIndex(s => s.Name);
        builder.HasIndex(s => s.City);
    }
}

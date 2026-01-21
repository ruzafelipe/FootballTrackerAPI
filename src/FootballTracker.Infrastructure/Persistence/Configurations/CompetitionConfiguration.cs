using FootballTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTracker.Infrastructure.Persistence.Configurations;

public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {   
        // Tabela        
        builder.ToTable("Competitions");

        // Chave primária
        builder.HasKey(c => c.Id);

        // Propriedades

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Season)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.Country)
            .HasMaxLength(100);

        builder.Property(c => c.Type)
            .IsRequired()
            .HasConversion<int>(); // enum → int

        builder.Property(c => c.StartDate)
            .IsRequired(false);

        builder.Property(c => c.EndDate)
            .IsRequired(false);

        builder.Property(c => c.IsActive)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .IsRequired(false);

        // Índices úteis
        builder.HasIndex(c => new { c.Name, c.Season })
            .IsUnique();
    }
}

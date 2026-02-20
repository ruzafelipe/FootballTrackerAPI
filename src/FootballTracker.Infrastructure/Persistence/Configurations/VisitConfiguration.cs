using FootballTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTracker.Infrastructure.Persistence;


public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        // 1. Table name
        builder.ToTable("Visits");
        // 2. Primary Key
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.UserId)
            .IsRequired();

        builder.Property(v => v.MatchId)
            .IsRequired();

        builder.Property(v => v.VisitedAt)
            .IsRequired();

        builder.Property(v => v.CreatedAt)
            .IsRequired();

        builder.HasOne(v => v.Match)
               .WithMany()
               .HasForeignKey(v => v.MatchId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(v => v.UserId); // Índice para consultas por usuário

        builder.HasIndex(v => v.MatchId); // Índice para consultas por Match

        builder.HasIndex(v => v.VisitedAt); // Índice para consultas por data de visita

        builder.HasIndex(v => new { v.UserId, v.MatchId })
               .IsUnique(); // Garante que um usuário não possa registrar múltiplas visitas para o mesmo jogo
    }
}


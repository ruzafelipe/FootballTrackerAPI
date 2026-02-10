using FootballTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTracker.Infrastructure.Persistence;

public class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.ToTable("Matches");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Status)
               .IsRequired();

        builder.Property(m => m.MatchDate)
               .IsRequired();

        builder.Property(m => m.CreatedByUserId)
               .IsRequired();

        builder.Property(m => m.CreatedAt)
               .IsRequired();

        builder.Property(m => m.ApprovedOrRejectedByUserId)
               .IsRequired(false);

        builder.Property(m => m.UpdatedAt)
               .IsRequired(false);

        builder.HasOne(m => m.Competition)
               .WithMany() // Uma competição pode ter muitos jogos
               .HasForeignKey(m => m.CompetitionId) // Chave estrangeira para a competição
               .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão em cascata

        builder.HasOne(m => m.Stadium)
               .WithMany() // Um estádio pode sediar muitos jogos
               .HasForeignKey(m => m.StadiumId) // Chave estrangeira para o estádio
               .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão em cascata

        builder.HasOne(m => m.HomeClub)
               .WithMany() // Um clube pode ser o clube da casa em muitos jogos
               .HasForeignKey(m => m.HomeClubId) // Chave estrangeira para o clube da casa
               .OnDelete(DeleteBehavior.Restrict); // Impede a exclusão em cascata

        builder.HasOne(m => m.AwayClub)
               .WithMany()
               .HasForeignKey(m => m.AwayClubId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => new { m.MatchDate, m.StadiumId })
               .IsUnique(); // Garante que não haja jogos duplicados na mesma data no mesmo estádio
    }
}
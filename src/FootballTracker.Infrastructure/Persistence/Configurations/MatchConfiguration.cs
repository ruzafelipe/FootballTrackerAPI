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

        builder.Property(m => m.MatchDate) 
            .IsRequired();// data obrigatória

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
    }
}
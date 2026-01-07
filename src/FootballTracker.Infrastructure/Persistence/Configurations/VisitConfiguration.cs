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
        // 3. Relationship with User
        builder.HasOne(v => v.User) //uma visita pertence a um usuário
               .WithMany() //um usuário pode ter muitas visitas
               .HasForeignKey(v => v.UserId) //fk
               .IsRequired() //o usuário é obrigatório
               .OnDelete(DeleteBehavior.Restrict); //impede exclusão em cascata

        builder.HasOne(v => v.Match)
               .WithMany()
               .HasForeignKey(v => v.MatchId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(v => v.CreatedAt)
               .IsRequired();
    }
}


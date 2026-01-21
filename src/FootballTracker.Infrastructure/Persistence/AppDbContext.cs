using FootballTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Persistence
{    
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Visit> Visits => Set<Visit>();
        public DbSet<Stadium> Stadiums => Set<Stadium>();
        public DbSet<Club> Clubs => Set<Club>();    
        public DbSet<Competition> Competitions => Set<Competition>();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais do modelo podem ser feitas aqui


          
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);

            /*Essa linha diz literalmente ao EF Core:

                “Procure neste assembly todas as classes que implementam
                IEntityTypeConfiguration<T> e aplique automaticamente.”

            Ou seja:

            Você não registra uma por uma

            Você não precisa lembrar delas

            Você não toca mais no DbContext
           */
        }
    }
}
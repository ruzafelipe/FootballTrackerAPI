using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Infrastructure.Persistence;
using FootballTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballTracker.Infrastructure.DependencyInjection;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString)
            )
        );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IStadiumRepository, StadiumRepository>();
        services.AddScoped<IClubRepository, ClubRepository>();
        services.AddScoped<ICompetitionRepository, CompetitionRepository>();

        return services;
    }
}

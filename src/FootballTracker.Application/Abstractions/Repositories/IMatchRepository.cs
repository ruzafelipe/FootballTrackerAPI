using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;

public interface IMatchRepository
{
    Task<bool> ExistsAsync(Guid matchId);

    Task<Match?> GetByIdAsync(Guid matchId);

    Task <bool> ExistsByDateAndClubsAsync(DateTime matchDate, Guid homeClubId, Guid awayClubId);

    Task AddAsync(Match match);
}
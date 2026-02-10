using FootballTracker.Domain.Entities;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.Abstractions.Repositories;

public interface IMatchRepository
{
    Task<bool> ExistsAsync(Guid matchId);

    Task<Match?> GetByIdAsync(Guid matchId);

    Task <bool> ExistsByDateAndClubsAsync(DateTime matchDate, Guid homeClubId, Guid awayClubId);

    Task<Match?> GetByStadiumAndDateAsync(Guid stadiumId, DateTime matchDate);

    Task AddAsync(Match match);

    Task UpdateAsync(Match match);

    Task<IReadOnlyList<Match>> GetAllByStatusesAsync(IReadOnlyCollection<MatchStatus> statuses);
}
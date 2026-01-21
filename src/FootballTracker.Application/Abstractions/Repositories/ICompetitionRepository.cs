using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;

public interface ICompetitionRepository
{
    Task<bool> ExistsByNameAndSeasonAsync(string competitionName, string season);
    Task<bool> ExistsByIdAsync(Guid competitionId);
    Task<Competition?> GetByIdAsync(Guid competitionId);
    Task AddAsync(Competition competition);
    Task UpdateAsync(Competition competition);   
    Task<IReadOnlyList<Competition>> GetAllActiveAsync(bool onlyActive = true);
}

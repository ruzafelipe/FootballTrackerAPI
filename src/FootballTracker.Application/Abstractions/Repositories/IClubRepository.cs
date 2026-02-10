using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;

public interface IClubRepository
{
    Task<bool> ExistsByNameAsync(string clubName);
    Task<bool> ExistsByIdAsync(Guid clubId);
    Task<Club?> GetByIdAsync(Guid clubId);
    Task AddAsync(Club club);
    Task UpdateAsync(Club club);   
    Task<IReadOnlyList<Club>> GetAllActiveAsync(bool onlyActive = true);
    Task<IReadOnlyList<Club>> GetAllAsync();

}
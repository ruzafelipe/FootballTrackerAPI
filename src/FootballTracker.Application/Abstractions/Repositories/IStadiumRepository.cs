using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;

public interface IStadiumRepository
{
    Task<bool> ExistsByNameAsync(string stadiumName);    
    Task<bool>ExistsById(Guid stadiumId);
    Task<Stadium?> GetByIdAsync(Guid stadiumId);
    Task AddAsync(Stadium stadium);
    Task UpdateAsync(Stadium stadium);
    Task<IReadOnlyList<Stadium>> GetAllActiveAsync(bool onlyActive = true);
    Task<IReadOnlyList<Stadium>> GetAllAsync();
}

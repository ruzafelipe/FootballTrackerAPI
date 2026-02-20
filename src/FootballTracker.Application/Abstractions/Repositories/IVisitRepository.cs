using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;

/*Um usuário não pode visitar o mesmo match duas vezes”

Ela é orquestrada na Application,
mas persistida depois na Infrastructure.
 
 */

public interface IVisitRepository
{
    Task<bool> ExistsAsync(Guid userId, Guid matchId);
    Task AddAsync(Visit visit);    
    Task<Visit?> GetByIdAsync(Guid visitId);
    Task<IReadOnlyList<Visit>> GetByUserIdAsync(Guid userId);
    Task<IReadOnlyList<Visit>> GetByMatchIdAsync(Guid matchId);

}
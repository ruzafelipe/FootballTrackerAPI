using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Visits.ListVisitsByMatch;

public sealed class ListVisitsByMatchHandler
{
    private readonly IVisitRepository _visitRepository;
        public ListVisitsByMatchHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }
        public async Task<Result<IReadOnlyList<Visit>>> HandleAsync(ListVisitsByMatchQuery query)
        {
            if(query.MatchId == Guid.Empty)
            {
                return Result<IReadOnlyList<Visit>>.Failure("Invalid match ID");
            }
    
            var visits = await _visitRepository.GetByMatchIdAsync(query.MatchId);
    
            return Result<IReadOnlyList<Visit>>.Success(visits);
    }
}

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Visits.ListVisitsByUser;

public sealed class ListVisitsByUserHandler
{
    private readonly IVisitRepository _visitRepository;
    public ListVisitsByUserHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    public async Task<Result<IReadOnlyList<Visit>>> HandleAsync(ListVisitsByUserQuery query)
    {
        if(query.UserId == Guid.Empty)
        {
            return Result<IReadOnlyList<Visit>>.Failure("Invalid user ID");
        }

        var visits = await _visitRepository.GetByUserIdAsync(query.UserId);

        return Result<IReadOnlyList<Visit>>.Success(visits);
    }
}

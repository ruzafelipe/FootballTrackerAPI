using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Matchs.ListMatches;

public sealed class ListMatchesHandler
{
    private readonly IMatchRepository _matchRepository;

    public ListMatchesHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }   


    public async Task<Result<IReadOnlyList<Match>>> HandleAsync(ListMatchesQuery query)
    {
        if (query.AllowedStatuses is null || !query.AllowedStatuses.Any())
            return Result<IReadOnlyList<Match>>.Failure("At least one match status must be provided.");

        var matches = await _matchRepository
            .GetAllByStatusesAsync(query.AllowedStatuses);

        return Result<IReadOnlyList<Match>>.Success(matches);
    }
}

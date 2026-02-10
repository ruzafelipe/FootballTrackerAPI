using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Matchs.ListMatches;

public sealed class ListMatchesHandler
{
    private readonly IMatchRepository _matchRepository;

    public ListMatchesHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }   


    public async Task<IReadOnlyList<Match>> HandleAsync(ListMatchesQuery query)
    {
         return await _matchRepository.GetAllByStatusesAsync(query.AllowedStatuses);
    }
}

using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.UseCases.Matchs.ListMatches;

public sealed class ListMatchesQuery
{
    public IReadOnlyCollection<MatchStatus> AllowedStatuses { get; }

    public ListMatchesQuery(IReadOnlyCollection<MatchStatus> allowedStatuses)
    {
        AllowedStatuses = allowedStatuses.ToList();
    }   

}

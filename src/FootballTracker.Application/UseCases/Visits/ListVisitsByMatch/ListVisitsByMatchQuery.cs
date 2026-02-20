namespace FootballTracker.Application.UseCases.Visits.ListVisitsByMatch;

public sealed class ListVisitsByMatchQuery
{
    public Guid MatchId { get; }
    public ListVisitsByMatchQuery(Guid matchId)
    {
        MatchId = matchId;
    }
}

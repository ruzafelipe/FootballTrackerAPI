namespace FootballTracker.Application.UseCases.Matchs.GetMatchById;

public sealed class GetMatchByIdQuery
{
    public Guid MatchId { get; }
    public GetMatchByIdQuery(Guid matchId)
    {
        MatchId = matchId;
    }
}

namespace FootballTracker.Application.UseCases.Competitions.GetCompetitionById;

public sealed class GetCompetitionByIdQuery
{
    public Guid Id { get; }
    public GetCompetitionByIdQuery(Guid id)
    {
        Id = id;
    }
}

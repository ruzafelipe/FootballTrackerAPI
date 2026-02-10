namespace FootballTracker.Application.UseCases.Competitions.ListCompetitions;

public sealed class ListCompetitionsQuery
{
    public bool OnlyActive { get; }
    public ListCompetitionsQuery(bool onlyActive = true)
    {
        OnlyActive = onlyActive;
    }
}

namespace FootballTracker.Application.UseCases.Stadiums.ListStadiums;

public sealed class ListStadiumsQuery
{
    public bool OnlyActive { get; }
    public ListStadiumsQuery(bool onlyActive = true)
    {
        OnlyActive = onlyActive;
    }
}

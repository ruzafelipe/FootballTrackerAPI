namespace FootballTracker.Application.UseCases.Clubs.ListClubs;

public sealed class ListClubsQuery
{
    public bool OnlyActive { get; }
    public ListClubsQuery(bool onlyActive = true)
    {
        OnlyActive = onlyActive;
    }
}

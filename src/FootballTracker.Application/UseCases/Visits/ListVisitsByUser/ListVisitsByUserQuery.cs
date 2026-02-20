namespace FootballTracker.Application.UseCases.Visits.ListVisitsByUser;

public sealed class ListVisitsByUserQuery
{
    public Guid UserId { get; }
    public ListVisitsByUserQuery(Guid userId)
    {
        UserId = userId;
    }
}

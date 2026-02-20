namespace FootballTracker.Application.UseCases.Visits.GetVisitById;

public sealed class GetVisitByIdQuery
{
    public Guid VisitId { get; }
    public GetVisitByIdQuery(Guid visitId)
    {
       VisitId = visitId;
    }
}

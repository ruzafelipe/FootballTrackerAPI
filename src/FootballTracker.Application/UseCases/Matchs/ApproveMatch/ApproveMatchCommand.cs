namespace FootballTracker.Application.UseCases.Matchs.ApproveMatch;

public sealed record ApproveMatchCommand
{
    public Guid Id { get; }
    public Guid ApprovedByUserId { get; }

    public ApproveMatchCommand(Guid id, Guid approvedByUserId)
    {
        Id = id;
        ApprovedByUserId = approvedByUserId;
    }

}

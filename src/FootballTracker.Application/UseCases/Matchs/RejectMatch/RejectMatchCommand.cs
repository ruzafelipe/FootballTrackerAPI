namespace FootballTracker.Application.UseCases.Matchs.RejectMatch;

public sealed class RejectMatchCommand
{
    public Guid Id { get; }
    public Guid RejectedByUserId { get; }
    public RejectMatchCommand(Guid id, Guid rejectedByUserId)
    {
        Id = id;
        RejectedByUserId = rejectedByUserId;
    }
}

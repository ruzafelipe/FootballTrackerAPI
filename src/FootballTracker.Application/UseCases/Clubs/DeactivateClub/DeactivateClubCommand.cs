namespace FootballTracker.Application.UseCases.Clubs.DeactivateClub;

public sealed class DeactivateClubCommand
{
    public Guid Id { get; }
    public DeactivateClubCommand(Guid id)
    {
        Id = id;
    }
}

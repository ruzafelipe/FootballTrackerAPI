namespace FootballTracker.Application.UseCases.Clubs.ActivateClub;

public sealed class ActivateClubCommand
{
    public Guid Id { get; }
    public ActivateClubCommand(Guid id)
    {
        Id = id;
    }
}

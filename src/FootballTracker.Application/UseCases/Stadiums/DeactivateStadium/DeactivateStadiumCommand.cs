namespace FootballTracker.Application.UseCases.Stadiums.DeactivateStadium;

public sealed class DeactivateStadiumCommand
{
    public Guid Id { get; }
    public DeactivateStadiumCommand(Guid id)
    {
        Id = id;
    }
}

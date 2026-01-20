namespace FootballTracker.Application.UseCases.Stadiums.ActivateStadium;

public sealed class ActivateStadiumCommand
{
    public Guid Id { get; }
    public ActivateStadiumCommand(Guid id)
    {
        Id = id;
    }
}

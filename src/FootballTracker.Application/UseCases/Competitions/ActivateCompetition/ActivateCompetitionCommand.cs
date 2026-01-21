namespace FootballTracker.Application.UseCases.Competitions.ActivateCompetition;

public sealed class ActivateCompetitionCommand
{
    public Guid Id { get; }
    public ActivateCompetitionCommand(Guid id)
    {
        Id = id;
    }
}

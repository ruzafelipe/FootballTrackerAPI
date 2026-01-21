namespace FootballTracker.Application.UseCases.Competitions.DeactivateCompetition;

public sealed class DeactivateCompetitionCommand
{
    public Guid Id { get; }
    public DeactivateCompetitionCommand(Guid id)
    {
        Id = id;
    }
}

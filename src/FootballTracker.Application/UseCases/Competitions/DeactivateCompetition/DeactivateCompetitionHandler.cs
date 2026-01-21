using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Competitions.DeactivateCompetition;

public sealed class DeactivateCompetitionHandler
{
    private readonly ICompetitionRepository _competitionRepository;

    public DeactivateCompetitionHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task<Result> HandleAsync(DeactivateCompetitionCommand command)
    {
        var competition = await _competitionRepository.GetByIdAsync(command.Id);
        if (competition is null)
            throw new KeyNotFoundException("Competition not found.");

        if (!competition.IsActive)
            return Result.Failure("Competition is already inactive.");

        competition.Deactivate();
        await _competitionRepository.UpdateAsync(competition);
        return Result.Success();
    }
}

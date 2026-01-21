using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Competitions.ActivateCompetition;

public sealed class ActivateCompetitionHandler
{
    private readonly ICompetitionRepository _competitionRepository;

    public ActivateCompetitionHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task<Result> HandleAsync(ActivateCompetitionCommand command)
    {
        var competition = await _competitionRepository.GetByIdAsync(command.Id);

        if (competition is null)
            throw new KeyNotFoundException("Competition not found.");

        if (competition.IsActive)
            return Result.Failure("Competition is already active.");

        competition.Activate();
        await _competitionRepository.UpdateAsync(competition);

        return Result.Success();
    }
}

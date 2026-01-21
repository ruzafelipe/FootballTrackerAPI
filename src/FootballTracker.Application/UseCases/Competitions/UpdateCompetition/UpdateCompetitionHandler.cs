using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Competitions.UpdateCompetition;

public sealed class UpdateCompetitionHandler
{
    private readonly ICompetitionRepository _competitionRepository;
    public UpdateCompetitionHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }
    public async Task<Result> HandleAsync(UpdateCompetitionCommand command)
    {
        var competition = await _competitionRepository.GetByIdAsync(command.Id);
        if (competition is null)
        {
            throw new KeyNotFoundException("Competition not found.");
        }
        competition.UpdateDetails(command.Name,
            command.Season,
            command.Country,
            command.StartDate,
            command.EndDate);

        await _competitionRepository.UpdateAsync(competition);

        return Result.Success();
    }
}

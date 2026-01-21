using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.UseCases.Competitions.RegisterCompetition;

public sealed class RegisterCompetitionHandler
{
    private readonly ICompetitionRepository _competitionRepository; 

    public RegisterCompetitionHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task<Result> HandleAsync(RegisterCompetitionCommand command)
    {
        if (await _competitionRepository
            .ExistsByNameAndSeasonAsync(command.Name, command.Season))
        {
            return Result.Failure("Competition already exists for this season.");
        }

        if (!Enum.IsDefined(typeof(CompetitionType), command.Type))
            return Result.Failure("Invalid competition type.");

        var competition = new Competition(
            command.Name,
            command.Season,
            (CompetitionType)command.Type,
            command.Country,            
            command.StartDate,
            command.EndDate
        );

        await _competitionRepository.AddAsync(competition);

        return Result.Success();
    }
}

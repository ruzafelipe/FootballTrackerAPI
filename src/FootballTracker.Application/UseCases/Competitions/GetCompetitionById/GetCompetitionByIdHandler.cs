using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Competitions.GetCompetitionById;

public sealed class GetCompetitionByIdHandler
{
    private readonly ICompetitionRepository _competitionRepository;

    public GetCompetitionByIdHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task<Result<Competition?>> HandleAsync(GetCompetitionByIdQuery query)
    {
        var competition = await _competitionRepository.GetByIdAsync(query.Id);

        if (competition is null)
        {
            return Result<Competition?>.Failure("Competition not found");
        }

        if (!competition.IsActive)
        {
            return Result<Competition?>.Failure("Competition is inactive");
        }

        return Result<Competition>.Success(competition);
    }
}

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Competitions.ListCompetitions;

public sealed class ListCompetitionHandler
{
    private readonly ICompetitionRepository _competitionRepository;
    public ListCompetitionHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }
    public async Task<IReadOnlyList<Competition>> HandleAsync(bool onlyActive = true)
    {
       return await _competitionRepository.GetAllActiveAsync(onlyActive);
    }
}

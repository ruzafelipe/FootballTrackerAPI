using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Competitions.ListCompetitions;

public sealed class ListCompetitionsHandler
{
    private readonly ICompetitionRepository _competitionRepository;
    public ListCompetitionsHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }
    public async Task<IReadOnlyList<Competition>> HandleAsync(ListCompetitionsQuery query)
    {
        if (query.OnlyActive)
            return await _competitionRepository.GetAllActiveAsync();

        return await _competitionRepository.GetAllAsync();
    }
}

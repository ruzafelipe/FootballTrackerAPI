using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Competitions.ListCompetitions;

public sealed class ListCompetitionsHandler
{
    private readonly ICompetitionRepository _competitionRepository;
    public ListCompetitionsHandler(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }
    public async Task<Result<IReadOnlyList<Competition>>> HandleAsync(ListCompetitionsQuery query)
    {
        var competitions = query.OnlyActive
         ? await _competitionRepository.GetAllActiveAsync()
         : await _competitionRepository.GetAllAsync();

        return Result<IReadOnlyList<Competition>>.Success(competitions);
    }
}

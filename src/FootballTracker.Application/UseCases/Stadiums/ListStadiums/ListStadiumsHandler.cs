using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Stadiums.ListStadiums;

public sealed class ListStadiumsHandler
{
    private readonly IStadiumRepository _stadiumRepository;

    public ListStadiumsHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<Result<IReadOnlyList<Stadium>>> HandleAsync(ListStadiumsQuery query)
    {
        var stadiums = query.OnlyActive
         ? await _stadiumRepository.GetAllActiveAsync()
         : await _stadiumRepository.GetAllAsync();

        return Result<IReadOnlyList<Stadium>>.Success(stadiums);
    }
}

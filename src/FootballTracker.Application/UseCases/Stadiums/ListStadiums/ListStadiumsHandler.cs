using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Stadiums.ListStadiums;

public sealed class ListStadiumsHandler
{
    private readonly IStadiumRepository _stadiumRepository;

    public ListStadiumsHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<IReadOnlyList<Stadium>> HandleAsync(ListStadiumsQuery query)
    {
        if (query.OnlyActive)
            return await _stadiumRepository.GetAllActiveAsync();

        return await _stadiumRepository.GetAllAsync();
    }
}

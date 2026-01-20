using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Stadiums.ListStadiums;

public sealed class ListStadiumHandler
{
    private readonly IStadiumRepository _stadiumRepository;

    public ListStadiumHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<IReadOnlyList<Stadium>> HandleAsync(bool onlyActive = true)
    {
       return await _stadiumRepository.GetAllActiveAsync(onlyActive);
    }
}

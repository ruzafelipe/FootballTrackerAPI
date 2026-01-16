using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Clubs.ListClubs;

public sealed class ListClubHandler
{
    private readonly IClubRepository _clubRepository;

    public ListClubHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<IReadOnlyList<Club>> HandleAsync(bool onlyActive = true)
    {
       return await _clubRepository.GetAllActiveAsync(onlyActive);
    }
}

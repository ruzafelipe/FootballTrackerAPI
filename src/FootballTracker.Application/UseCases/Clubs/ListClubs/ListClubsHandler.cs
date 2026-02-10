using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Clubs.ListClubs;

public sealed class ListClubsHandler
{
    private readonly IClubRepository _clubRepository;

    public ListClubsHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<IReadOnlyList<Club>> HandleAsync(ListClubsQuery query)
    {
       if (query.OnlyActive)
       {
            return await _clubRepository.GetAllActiveAsync();
       }

       return await _clubRepository.GetAllAsync();

    }
}

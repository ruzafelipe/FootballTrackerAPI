using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Clubs.ListClubs;

public sealed class ListClubsHandler
{
    private readonly IClubRepository _clubRepository;

    public ListClubsHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<Result<IReadOnlyList<Club>>> HandleAsync(ListClubsQuery query)
    {

        var clubs = query.OnlyActive
         ? await _clubRepository.GetAllActiveAsync()
         : await _clubRepository.GetAllAsync();

        return Result<IReadOnlyList<Club>>.Success(clubs);

    }
}

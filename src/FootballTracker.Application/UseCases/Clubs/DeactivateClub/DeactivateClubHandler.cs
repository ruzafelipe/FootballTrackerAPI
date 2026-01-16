using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Clubs.DeactivateClub;

public sealed class DeactivateClubHandler
{
    private readonly IClubRepository _clubRepository;
    public DeactivateClubHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }
    public async Task<Result> HandleAsync(DeactivateClubCommand command)
    {
        var club = await _clubRepository.GetByIdAsync(command.Id);

        if (club is null)
            throw new KeyNotFoundException("Club not found.");

        if (!club.IsActive)
            return Result.Failure("Club is already inactive.");

        club.Deactivate();
        await _clubRepository.UpdateAsync(club);
        return Result.Success();
    }
}

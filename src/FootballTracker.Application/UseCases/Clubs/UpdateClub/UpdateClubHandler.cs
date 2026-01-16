using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Clubs.UpdateClub;

public sealed class UpdateClubHandler
{
    private readonly IClubRepository _clubRepository;

    public UpdateClubHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<Result> HandleAsync(UpdateClubCommand command)
    {
        var club = await _clubRepository.GetByIdAsync(command.Id);
        if (club is null)
            throw new KeyNotFoundException("Club not found.");
        club.ValidateName(command.Name);
        club.ValidateLocation(command.City, command.State, command.Country);
        club.ValidateFoundedAt(command.FoundedAt);
        club.ValidateLogoUrl(command.LogoUrl);
        await _clubRepository.UpdateAsync(club);

        return Result.Success();
    }
}

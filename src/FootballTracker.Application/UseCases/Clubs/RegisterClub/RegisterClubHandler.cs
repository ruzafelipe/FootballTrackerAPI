using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Clubs.RegisterClub;

public sealed class RegisterClubHandler
{
    private readonly IClubRepository _clubRepository;

    public RegisterClubHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<Result> HandleAsync(RegisterClubCommand command)
    {
        if (await _clubRepository.ExistsByNameAsync(command.Name))
            return Result.Failure("A club with this name already exists.");

        var club = new Club(command.Name,
            command.City,
            command.State,
            command.Country,
            command.FoundedAt,
            command.LogoUrl);

        await _clubRepository.AddAsync(club);

        return Result.Success();
    }

}

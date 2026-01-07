

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases;

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
            return Result.Failure("Club already exists.");

        var club = new Club(command.Name);

        await _clubRepository.AddAsync(club);

        return Result.Success();
    }

}

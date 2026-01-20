using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Stadiums.UpdateStadium;

public sealed class UpdateStadiumHandler
{
    private readonly IStadiumRepository _stadiumRepository;

    public UpdateStadiumHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<Result> HandleAsync(UpdateStadiumCommand command)
    {
        var stadium = await _stadiumRepository.GetByIdAsync(command.Id);

        if (stadium is null)
            return Result.Failure("Stadium not found.");

        stadium.ValidateName(command.Name);
        stadium.ValidateLocation(command.City, command.State, command.Country);
        stadium.ValidateCapacity(command.Capacity);
        stadium.ValidateOpenedDate(command.OpenedDate);
        stadium.ValidatePhotoUrl(command.PhotoUrl);

        await _stadiumRepository.UpdateAsync(stadium);
        return Result.Success();
    }
}

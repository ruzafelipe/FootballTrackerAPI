using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Stadiums.DeactivateStadium;

public sealed class DeactivateStadiumHandler
{
    private readonly IStadiumRepository _stadiumRepository;
    public DeactivateStadiumHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<Result> HandleAsync(DeactivateStadiumCommand command)
    {
        var stadium = await _stadiumRepository.GetByIdAsync(command.Id);

        if (stadium is null)
            throw new KeyNotFoundException("Stadium not found.");

        if (!stadium.IsActive)
            throw new KeyNotFoundException("Stadium is already inactive.");

        stadium.Deactivate();
        await _stadiumRepository.UpdateAsync(stadium);
        return Result.Success();
    }
}

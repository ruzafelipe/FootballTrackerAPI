using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;

namespace FootballTracker.Application.UseCases.Stadiums.ActivateStadium;

public sealed class ActivateStadiumHandler
{
    private readonly IStadiumRepository _stadiumRepository;
    public ActivateStadiumHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }
    public async Task<Result> HandleAsync(ActivateStadiumCommand command)
    {
        var stadium = await _stadiumRepository.GetByIdAsync(command.Id);

        if (stadium is null)
            throw new KeyNotFoundException("Stadium not found.");

        if (stadium.IsActive)
            return Result.Failure("Stadium is already active.");

        stadium.Activate();
        await _stadiumRepository.UpdateAsync(stadium);
        return Result.Success();
    }
}

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;


namespace FootballTracker.Application.UseCases.Stadiums.RegisterStadium;

public sealed class RegisterStadiumHandler
{
    private readonly IStadiumRepository _stadiumRepository;

    public RegisterStadiumHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<Result> HandleAsync(RegisterStadiumCommand command)
    {
        if (await _stadiumRepository.ExistsByNameAsync(command.Name))
            return Result.Failure("Stadium already exists.");

        var stadium = new Stadium(command.Name, command.City);

        await _stadiumRepository.AddAsync(stadium);

        return Result.Success();
    }
}
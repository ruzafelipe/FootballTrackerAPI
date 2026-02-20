using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Stadiums.GetStadiumById;

public sealed class GetStadiumByIdHandler
{
    private readonly IStadiumRepository _stadiumRepository;
    public GetStadiumByIdHandler(IStadiumRepository stadiumRepository)
    {
        _stadiumRepository = stadiumRepository;
    }

    public async Task<Result<Stadium>> HandleAsync(GetStadiumByIdQuery query)
    {
        var stadium = await _stadiumRepository.GetByIdAsync(query.Id);

        if (stadium is null)
            return Result<Stadium>.Failure("Stadium not found");

        if (!stadium.IsActive)
            return Result<Stadium>.Failure("Stadium is inactive");

        return Result<Stadium>.Success(stadium);
    }
}

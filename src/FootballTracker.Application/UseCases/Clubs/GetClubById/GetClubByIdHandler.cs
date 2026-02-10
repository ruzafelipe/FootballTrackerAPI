using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Clubs.GetClubById;

public sealed class GetClubByIdHandler
{
    private readonly IClubRepository _clubRepository;

    public GetClubByIdHandler(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public async Task<Result<Club?>> HandleAsync(GetClubByIdQuery query)
    {
        var club = await _clubRepository.GetByIdAsync(query.Id);

        if (club is null)
            return Result<Club?>.Failure("Club not found");
        //Posso tirar isso depois para mostrar até mesmo os clubes inativos
        if (!club.IsActive)
            return Result<Club?>.Failure("Club is inactive");

        return Result<Club?>.Success(club);
    }
}

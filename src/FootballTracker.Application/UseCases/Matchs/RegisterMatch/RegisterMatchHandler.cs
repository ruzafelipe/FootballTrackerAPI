using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Matchs.RegisterMatch;

public sealed class RegisterMatchHandler
{
    private readonly IMatchRepository _matchRepository;
    private readonly IStadiumRepository _stadiumRepository;
    private readonly IClubRepository _clubRepository;

    public RegisterMatchHandler(IMatchRepository matchRepository, IStadiumRepository stadiumRepository, IClubRepository clubRepository)
    {
        _matchRepository = matchRepository;
        _stadiumRepository = stadiumRepository;
        _clubRepository = clubRepository;   
    }

    public async Task<Result> HandleAsync(RegisterMatchCommand command)
    {
        if (await _matchRepository.ExistsByDateAndClubsAsync(command.MatchDate, command.HomeClubId, command.AwayClubId))
            return Result.Failure("Match between these clubs on the specified date already exists.");

        if (command.HomeClubId == command.AwayClubId)
            return Result.Failure("Home and away clubs must be different.");

        if(!await _stadiumRepository.ExistsById(command.StadiumId)) 
            return Result.Failure("Stadium does not exist.");
                
        if (!await _clubRepository.ExistsByIdAsync(command.HomeClubId))
            return Result.Failure("Home club does not exist.");        
        if (!await _clubRepository.ExistsByIdAsync(command.AwayClubId))
            return Result.Failure("Away club does not exist.");

        var match = new Match(command.MatchDate, command.StadiumId,  command.HomeClubId, command.AwayClubId);
        await _matchRepository.AddAsync(match);
        return Result.Success();
    }
}
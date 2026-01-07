using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases;

public class RegisterVisitHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly IVisitRepository _visitRepository;

    public RegisterVisitHandler(
        IUserRepository userRepository,
        IMatchRepository matchRepository,
        IVisitRepository visitRepository)
    {
        _userRepository = userRepository;
        _matchRepository = matchRepository;
        _visitRepository = visitRepository;
    }

    public async Task<Result> HandleAsync(RegisterVisitCommand command)
    {
        // 1. user exists?
        if (!await _userRepository.ExistsAsync(command.UserId))
            return Result.Failure("User does not exist.");
        // 2. match exists?
        if (!await _matchRepository.ExistsAsync(command.MatchId))
            return Result.Failure("Match does not exist.");     

        // 3. Prevent duplicate visit
        if(await _visitRepository.ExistsAsync(command.UserId, command.MatchId))
            return Result.Failure("Visit already registered for this match.");

        // 4. Create domain entity
        var visit = new Visit(command.UserId, command.MatchId); 

        // 5. Persist
        await _visitRepository.AddAsync(visit);

        // 6. Return success
        return Result.Success();
    }
}


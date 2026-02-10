using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.UseCases.Matchs.RejectMatch;

public sealed class RejectMatchHandler
{
    private readonly IMatchRepository _matchRepository;

    public RejectMatchHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<Result> HandleAsync(RejectMatchCommand command)
    {
        var match = await _matchRepository.GetByIdAsync(command.Id);
        if (match is null)
        {
            return Result.Failure("Match not found.");
        }

        if (match.Status == MatchStatus.Rejected)
        {
            return Result.Failure("Match is already rejected.");
        }

        match.Reject(command.RejectedByUserId);
        await _matchRepository.UpdateAsync(match);

        return Result.Success();
    }
}

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.UseCases.Matchs.ApproveMatch;

public sealed class ApproveMatchHandler
{
    private readonly IMatchRepository _matchRepository;

    public ApproveMatchHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<Result> HandleAsync(ApproveMatchCommand command)
    {
        var match = await _matchRepository.GetByIdAsync(command.Id);
        if (match is null)
        {
            return Result.Failure("Match not found.");
        }

        if (match.Status == MatchStatus.Approved)
        {
            return Result.Failure("Match is already approved.");
        }

        match.Approve(command.ApprovedByUserId);
        await _matchRepository.UpdateAsync(match);

        return Result.Success();
    }

}

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Application.DTOs;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Visits.RegisterVisit;

public class RegisterVisitHandler
{

    private readonly IMatchRepository _matchRepository;
    private readonly IVisitRepository _visitRepository;

    public RegisterVisitHandler(
        IMatchRepository matchRepository,
        IVisitRepository visitRepository)
    {
        _matchRepository = matchRepository;
        _visitRepository = visitRepository;
    }

    public async Task<Result> HandleAsync(RegisterVisitCommand command)
    {
        
        var match = await ResolveMatchAsync(command);

       
        var visit = new Visit(
            command.UserId,
            match.Id,
            command.VisitDate
        );
        
        await _visitRepository.AddAsync(visit);

        return Result.Success();
    }

    // -------------------------
    // 🔽 MÉTODOS PRIVADOS
    // -------------------------

    private async Task<Match> ResolveMatchAsync(RegisterVisitCommand command)
    {
        if (command.MatchId.HasValue)
            return await GetExistingMatchAsync(command.MatchId.Value);

        if (command.MatchData is null)
            throw new ArgumentException("Match data must be provided when MatchId is not informed.");

        return await CreateMatchIfNotExistsAsync(
            command.MatchData,
            command.UserId
        );
    }

    private async Task<Match> GetExistingMatchAsync(Guid matchId)
    {
        var match = await _matchRepository.GetByIdAsync(matchId);

        if (match is null)
            throw new KeyNotFoundException("Match not found.");

        return match;
    }

    private async Task<Match> CreateMatchIfNotExistsAsync(
        RegisterMatchData dataMatch,
        Guid createdByUserId)
    {
        var existingMatch = await _matchRepository.GetByStadiumAndDateAsync(dataMatch.StadiumId, dataMatch.MatchDate);

        if (existingMatch is not null)
            return existingMatch;

        var match = new Match(
            dataMatch.CompetitionId,
            dataMatch.StadiumId,
            dataMatch.HomeClubId,
            dataMatch.AwayClubId,
            createdByUserId,
            dataMatch.MatchDate
        );

        await _matchRepository.AddAsync(match);

        return match;
    }
}


using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Application.UseCases.Matchs.GetMatchById;

public sealed class GetMatchByIdHandler
{
    private readonly IMatchRepository _matchRepository;

    public GetMatchByIdHandler(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }


    public async Task<Result<Match?>> HandleAsync(GetMatchByIdQuery query)
    {
        var match = await _matchRepository.GetByIdAsync(query.MatchId);
        if (match is null)
            return Result<Match?>.Failure("Match not found");
        //Posso remover essa verificação se quiser permitir acesso a partidas rejeitadas
        if (match.Status == MatchStatus.Rejected)        
            return Result<Match?>.Failure("Match is rejected");
        

        return Result<Match?>.Success(match);
    }
}

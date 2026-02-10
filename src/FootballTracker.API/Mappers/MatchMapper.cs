using FootballTracker.API.DTOs.Matchs;
using FootballTracker.Domain.Entities;

namespace FootballTracker.API.Mappers;

public sealed class MatchMapper
{
    public static MatchListResponse ToListResponse(Match match)
    {
        return new MatchListResponse
        {
            Id = match.Id,
            CompetitionId = match.CompetitionId,
            StadiumId = match.StadiumId,
            HomeClubId = match.HomeClubId,
            AwayClubId = match.AwayClubId,
            MatchDate = match.MatchDate,
            Status = match.Status
        };
    }

    public static MatchDetailsResponse ToDetailsResponse(Match match)
    {
        return new MatchDetailsResponse
        {
            Id = match.Id,
            MatchDate = match.MatchDate,
            HomeClubId = match.HomeClubId,
            AwayClubId = match.AwayClubId,
            CompetitionId = match.CompetitionId,
            StadiumId = match.StadiumId,
            Status = match.Status,
            CreatedByUserId = match.CreatedByUserId,
            ApprovedOrRejectedByUserId = match.ApprovedOrRejectedByUserId
        };
    }
}

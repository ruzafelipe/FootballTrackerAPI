using FootballTracker.API.DTOs.Visits;
using FootballTracker.Domain.Entities;

namespace FootballTracker.API.Mappers;

public sealed class VisitMapper
{
    public static VisitListResponse ToListResponse(Visit visit)
    {
        return new VisitListResponse
        {
            Id = visit.Id,
            VisitedAt = visit.VisitedAt,
            StadiumName = visit.Match.Stadium.Name,
            CompetitionName = visit.Match.Competition.Name,
            HomeClubName = visit.Match.HomeClub.Name,
            AwayClubName = visit.Match.AwayClub.Name
        };
    }

    public static VisitDetailsResponse ToDetailsResponse(Visit visit)
    {
        return new VisitDetailsResponse
        {
            Id = visit.Id,
            VisitedAt = visit.VisitedAt,
            CreatedAt = visit.CreatedAt,
            UserId = visit.UserId,
            MatchId = visit.MatchId,
            StadiumName = visit.Match.Stadium.Name,
            CompetitionName = visit.Match.Competition.Name,
            HomeClubName = visit.Match.HomeClub.Name,
            AwayClubName = visit.Match.AwayClub.Name
        };
    }
}

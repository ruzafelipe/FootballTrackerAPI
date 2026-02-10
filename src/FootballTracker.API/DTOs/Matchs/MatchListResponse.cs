using FootballTracker.Domain.Enums;

namespace FootballTracker.API.DTOs.Matchs;

public sealed class MatchListResponse
{
    public Guid Id { get; set; }
    public Guid CompetitionId { get; set; }
    public Guid StadiumId { get; set; }
    public Guid HomeClubId { get; set; }
    public Guid AwayClubId { get; set; }

    public DateTime MatchDate { get; set; }
    public MatchStatus Status { get; set; }
}

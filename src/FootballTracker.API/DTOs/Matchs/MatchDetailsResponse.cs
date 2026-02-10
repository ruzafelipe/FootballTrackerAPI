using FootballTracker.Domain.Enums;

namespace FootballTracker.API.DTOs.Matchs;

public sealed class MatchDetailsResponse
{
    public Guid Id { get; set; }
    public DateTime MatchDate { get; set; }
    public Guid HomeClubId { get; set; } 
    public Guid AwayClubId { get; set; }       
    public Guid CompetitionId { get; set; }
    public Guid StadiumId { get; set; }
    public MatchStatus Status { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid? ApprovedOrRejectedByUserId { get; set; }

}

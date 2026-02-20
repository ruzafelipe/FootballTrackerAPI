namespace FootballTracker.API.DTOs.Visits;

public sealed class VisitListResponse
{
    public Guid Id { get; set; }
    public DateTime VisitedAt { get; set; }
    public string StadiumName { get; set; } = string.Empty;
    public string CompetitionName { get; set; } = string.Empty;
    public string HomeClubName { get; set; } = string.Empty;
    public string AwayClubName { get; set; } = string.Empty;
}

namespace FootballTracker.API.DTOs.Matchs;

public sealed class RegisterMatchRequest
{
    public DateTime MatchDate { get; init; }
    public Guid StadiumId { get; init; }
    public Guid HomeClubId { get; init; }
    public Guid AwayClubId { get; init; }
    
}
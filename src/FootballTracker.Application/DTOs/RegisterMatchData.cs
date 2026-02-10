namespace FootballTracker.Application.DTOs;

public sealed class RegisterMatchData
{
    public Guid CompetitionId { get; init; }
    public Guid StadiumId { get; init; }
    public Guid HomeClubId { get; init; }
    public Guid AwayClubId { get; init; }
    public DateTime MatchDate { get; init; }
}

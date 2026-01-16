namespace FootballTracker.Application.UseCases.Matchs.RegisterMatch;


public sealed class RegisterMatchCommand
{
    public DateTime MatchDate { get; init; }
    public Guid StadiumId { get; init; }
    public Guid HomeClubId { get; init; }
    public Guid AwayClubId { get; init; }
    

    public RegisterMatchCommand(DateTime matchDate, Guid stadiumId, Guid homeClubId, Guid awayClubId)
    {
        MatchDate = matchDate;
        StadiumId = stadiumId;
        HomeClubId = homeClubId;
        AwayClubId = awayClubId;
        
    }
}


namespace FootballTracker.API.DTOs.Visits;

public class RegisterVisitRequest
{
    public Guid UserId { get; set; } 
    public Guid MatchId { get; set; }

}


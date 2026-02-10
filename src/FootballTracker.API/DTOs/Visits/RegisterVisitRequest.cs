using FootballTracker.Application.DTOs;

namespace FootballTracker.API.DTOs.Visits;

public class RegisterVisitRequest
{
    public Guid UserId { get; set; } 
    public DateTime VisitDate { get; set; }
    public Guid? MatchId { get; set; }
    public RegisterMatchData? MatchData { get; set; }

}


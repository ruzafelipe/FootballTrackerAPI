namespace FootballTracker.API.DTOs.Competitions;

public sealed class RegisterCompetitionRequest
{
    public string Name { get; set; } = null!;
    public string Season { get; set; } = null!;
    public string? Country { get; set; }
    public int Type { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

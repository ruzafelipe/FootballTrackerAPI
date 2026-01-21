namespace FootballTracker.API.DTOs.Competitions;

public sealed class UpdateCompetitionRequest
{
    public string? Name { get; set; }
    public string? Season { get; set; }
    public string? Country { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

namespace FootballTracker.API.DTOs.Competitions;

public sealed class CompetitionDetailsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Season { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? Country { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }   
    public bool IsActive { get; set; }
}

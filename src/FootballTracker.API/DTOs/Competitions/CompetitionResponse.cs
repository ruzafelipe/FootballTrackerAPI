namespace FootballTracker.API.DTOs.Competitions;

public sealed class CompetitionResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Season { get; set; } = null!;
    public string Type { get; set; } = null!;
}

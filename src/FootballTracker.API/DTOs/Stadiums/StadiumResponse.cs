namespace FootballTracker.API.DTOs.Stadiums;

public sealed class StadiumResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string City { get; init; } = null!;
    public string State { get; init; } = null!;
    public string Country { get; init; } = null!;
    public int Capacity { get; init; }
    public DateTime OpenedAt { get; init; }
    public string? ImageUrl { get; init; }
}

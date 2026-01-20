namespace FootballTracker.API.DTOs.Stadiums;

public sealed class UpdateStadiumRequest
{
    public string Name { get; init; } = null!;
    public string City { get; init; } = null!;
    public string State { get; init; } = null!;
    public string Country { get; init; } = null!;
    public int Capacity { get; init; } = 0;
    public DateTime OpenedDate { get; init; } = DateTime.Now ;
    public string? PhotoUrl { get; init; }
}

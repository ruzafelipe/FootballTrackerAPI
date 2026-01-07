namespace FootballTracker.API.DTOs.Stadiums;

public sealed class RegisterStadiumRequest
{
    public string Name { get; init; } = null!;
    public string? City { get; init; }
}

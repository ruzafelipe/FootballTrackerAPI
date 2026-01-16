namespace FootballTracker.API.DTOs.Clubs;

public sealed class RegisterClubRequest
{
    public string Name { get; init; } = null!;    
    public string City { get; init; } = null!;
    public string State { get; init; } = null!;
    public string Country { get; init; } = null!;
    public DateTime? FoundedAt { get; init; }
    public string? LogoUrl { get; init; }

}

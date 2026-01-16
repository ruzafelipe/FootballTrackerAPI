namespace FootballTracker.Application.UseCases.Clubs.UpdateClub;

public sealed class UpdateClubCommand
{
    public Guid Id { get; }
    public string Name { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public DateTime? FoundedAt { get; }
    public string? LogoUrl { get; }

    public UpdateClubCommand(Guid id,
        string name,
        string city,
        string state,
        string country,
        DateTime? foundedAt,
        string? logoUrl)
    {
        Id = id;
        Name = name;
        City = city;
        State = state;
        Country = country;
        FoundedAt = foundedAt;
        LogoUrl = logoUrl;
    }
}

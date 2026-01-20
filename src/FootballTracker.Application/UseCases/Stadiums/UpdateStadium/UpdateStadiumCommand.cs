namespace FootballTracker.Application.UseCases.Stadiums.UpdateStadium;

public sealed class UpdateStadiumCommand
{
    public Guid Id { get;}
    public string Name { get;} 
    public string City { get;}
    public string State { get; }
    public string Country { get; }
    public int Capacity { get; }
    public DateTime OpenedDate { get; }
    public string? PhotoUrl { get; }

    public UpdateStadiumCommand(
        Guid id,
        string name,
        string city,
        string state,
        string country,
        int capacity,
        DateTime openedDate,
        string? photoUrl)
    {
        Id = id;
        Name = name;
        City = city;
        State = state;
        Country = country;
        Capacity = capacity;
        OpenedDate = openedDate;
        PhotoUrl = photoUrl;
    }
}

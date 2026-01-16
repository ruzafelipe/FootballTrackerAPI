namespace FootballTracker.Application.UseCases.Stadiums.RegisterStadium;
public sealed class RegisterStadiumCommand
{
    public string Name;
    public string? City;

    public RegisterStadiumCommand(string name, string? city)
    {
        Name = name;
        City = city;
    }
}
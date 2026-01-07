namespace FootballTracker.Application.UseCases;
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
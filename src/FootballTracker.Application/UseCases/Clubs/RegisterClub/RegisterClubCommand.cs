namespace FootballTracker.Application.UseCases;

public sealed class RegisterClubCommand
{
    public string Name { get; }
    
    public RegisterClubCommand(string name)
    {
        Name = name;       
    }
}
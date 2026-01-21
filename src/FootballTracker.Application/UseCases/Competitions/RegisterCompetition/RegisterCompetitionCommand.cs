namespace FootballTracker.Application.UseCases.Competitions.RegisterCompetition;

public sealed class RegisterCompetitionCommand
{
    public string Name { get; }
    public string Season { get; }
    public int Type { get; }
    public string? Country { get; }
    
    public DateTime? StartDate { get; }
    public DateTime? EndDate { get; }

    public RegisterCompetitionCommand(
        string name,
        string season,
        int type,
        string? country,        
        DateTime? startDate,
        DateTime? endDate)
    {
        Name = name;
        Season = season;
        Type = type;
        Country = country;        
        StartDate = startDate;
        EndDate = endDate;
    }
}

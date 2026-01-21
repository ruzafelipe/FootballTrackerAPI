namespace FootballTracker.Application.UseCases.Competitions.UpdateCompetition;

public sealed class UpdateCompetitionCommand
{
    public Guid Id { get; }
    public string Name { get; }
    public string Season { get; }
    public string? Country { get; }
    public DateTime? StartDate { get; } 
    public DateTime? EndDate { get; }

    public UpdateCompetitionCommand(
        Guid id,
        string name,
        string season,
        string? country,        
        DateTime? startDate,
        DateTime? endDate)
    {
        Id = id;
        Name = name;
        Season = season;
        Country = country;        
        StartDate = startDate;
        EndDate = endDate;
    }


}

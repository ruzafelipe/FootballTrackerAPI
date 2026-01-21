using FootballTracker.API.DTOs.Competitions;
using FootballTracker.Domain.Entities;

namespace FootballTracker.API.Mappers;

public static class CompetitionMapper
{

    public static CompetitionResponse ToResponse(this Competition competition)
    {
        return new CompetitionResponse
        {
            Id = competition.Id,
            Name = competition.Name,
            Season = competition.Season,
            Type = competition.Type.ToString()            
        };
    }

    public static CompetitionDetailsResponse ToDetailsResponse(this Competition competition)
    {
        return new CompetitionDetailsResponse
        {
            Id = competition.Id,
            Name = competition.Name,
            Season = competition.Season,
            Type = competition.Type.ToString(),
            Country = competition.Country,
            StartDate = competition.StartDate,
            EndDate = competition.EndDate,
            IsActive = competition.IsActive
        };
    }
}

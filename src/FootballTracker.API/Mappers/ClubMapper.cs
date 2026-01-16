using FootballTracker.API.DTOs.Clubs;
using FootballTracker.Domain.Entities;

namespace FootballTracker.API.Mappers;

public static class ClubMapper
{
    public static ClubResponse ToResponse(Club club)
    {
        return new ClubResponse
        {
            Id = club.Id,
            Name = club.Name,
            City = club.City,
            State = club.State,
            Country = club.Country,
            FoundedAt = club.FoundedAt,
            LogoUrl = club.LogoUrl,
            IsActive = club.IsActive
        };
    }

    public static ClubDetailsResponse ToDetailsResponse(Club club)
    {
        return new ClubDetailsResponse
        {
            Id = club.Id,
            Name = club.Name,
            City = club.City,
            State = club.State,
            Country = club.Country,
            FoundedAt = club.FoundedAt,
            LogoUrl = club.LogoUrl,
            IsActive = club.IsActive
        };
    }
}

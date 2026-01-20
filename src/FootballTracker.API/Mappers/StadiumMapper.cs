using FootballTracker.API.DTOs.Stadiums;
using FootballTracker.Domain.Entities;

namespace FootballTracker.API.Mappers;

public static class StadiumMapper
{
    public static StadiumResponse ToResponse(Stadium stadium)
    {
        return new StadiumResponse
        {
            Id = stadium.Id,
            Name = stadium.Name,
            City = stadium.City,
            State = stadium.State,
            Country = stadium.Country,
            Capacity = stadium.Capacity,
            OpenedAt = stadium.OpenedDate,
            ImageUrl = stadium.PhotoUrl
        };
    }

    public static StadiumDetailsResponse ToDetailsResponse(Stadium stadium)
    {
        return new StadiumDetailsResponse
        {
            Id = stadium.Id,
            Name = stadium.Name,
            City = stadium.City,
            State = stadium.State,
            Country = stadium.Country,
            Capacity = stadium.Capacity,
            ImageUrl = stadium.PhotoUrl,
            IsActive = stadium.IsActive
        };
    }
}

using FootballTracker.Domain.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Domain.Entities;

public class Competition : BaseEntity
{
    public string Name { get; private set; }
    public CompetitionType Type { get; private set; }
    public string Season { get; private set; }
    public string? Country { get; private set; }

    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Competition() { }

    public Competition(
        string name,
        string season,
        CompetitionType type,
        string? country = null,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        ValidateName(name);
        ValidateSeason(season);
        ValidateCountry(country);
        ValidateDates(startDate, endDate);
        IsActive = true;
        Type = type;
        CreatedAt = DateTime.Now;
    }

    public void UpdateDetails(
        string name,
        string season,
        string? country,
        DateTime? startDate,
        DateTime? endDate)
    {
        ValidateName(name);
        ValidateSeason(season);
        ValidateDates(startDate, endDate);
        ValidateCountry(country);

        Name = name;
        Season = season;
        Country = country;
        StartDate = startDate;
        EndDate = endDate;

        Touch();
    }


    // Regras de domínio

    public void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Competition name cannot be empty.");
        if (name.Length > 150)
            throw new ArgumentException("Competition name is too long.");
        Name = name.Trim();
        Touch();
    }

    public void ValidateSeason(string season)
    {
        if (string.IsNullOrWhiteSpace(season))
            throw new ArgumentException("Season cannot be empty.");
        if (season.Length > 50)
            throw new ArgumentException("Season is too long.");
        Season = season.Trim();
        Touch();
    }

    public void ValidateCountry(string? country)
    {
        if (!string.IsNullOrWhiteSpace(country))
            Country = country.Trim();

        Touch();
    }

    public void ValidateDates(DateTime? startDate, DateTime? endDate)
    {
        if (startDate.HasValue && endDate.HasValue && endDate < startDate)
            throw new ArgumentException("End date cannot be before start date.");

        StartDate = startDate;
        EndDate = endDate;
        Touch();
    }

    public void Activate()
    {
        IsActive = true;
        Touch();
    }

    public void Deactivate()
    {
        IsActive = false;
        Touch();
    }

    public void Touch()
    {
        UpdatedAt = DateTime.Now;
    }






}

using FootballTracker.Domain.Common;

namespace FootballTracker.Domain.Entities;

/*🧠 Decisão aqui

City é opcional

Não modelamos endereço completo ainda

Evitamos overengineering

 */

public class Stadium : BaseEntity
{
    public string Name { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public int Capacity { get; private set; }
    public DateTime OpenedDate { get; private set; }    
    public string? PhotoUrl { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    protected Stadium() { }

    public Stadium(
       string name,
       string city,
       string state,
       string country,
       int capacity,
       DateTime openedAt,       
       string? photoUrl = null)
    {
        ValidateName(name);
        ValidateLocation(city, state, country);
        ValidateOpenedDate(openedAt);
        ValidateCapacity(capacity);
        ValidatePhotoUrl(photoUrl);

        IsActive = true;
        CreatedAt = DateTime.Now;
    }

    // Regras de domínio

    public void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Stadium name cannot be empty.");
        if (name.Length > 150)
            throw new ArgumentException("Stadium name is too long.");
        Name = name.Trim();
        Touch();
    }

    public void ValidateLocation(string city, string state, string country)
    {      
        if(string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty.");

        if(string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State cannot be empty.");

        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty.");

        City = city.Trim();
        State = state.Trim();
        Country = country.Trim();
        Touch();
    }

    public void ValidateCapacity(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException("Capacity cannot be negative.");
        Capacity = capacity;
        Touch();
    }

    public void ValidateOpenedDate(DateTime openedDate)
    {
        if (openedDate > DateTime.Now)
            throw new ArgumentException("Opened date cannot be in the future.");
        OpenedDate = openedDate;
        Touch();
    }

    public void ValidatePhotoUrl(string? photoUrl)
    {
        if (!string.IsNullOrWhiteSpace(photoUrl) &&
            !Uri.IsWellFormedUriString(photoUrl, UriKind.Absolute))
            throw new ArgumentException("Invalid photo URL.");

        PhotoUrl = photoUrl;
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

using FootballTracker.Domain.Common;

namespace FootballTracker.Domain.Entities;

/*🧠 Pontos importantes

Construtor garante estado válido

protected constructor → compatível com EF 

Sem validação exagerada (KISS)

 */

public class Club : BaseEntity
{
    public string Name { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public DateTime? FoundedAt { get; private set; }
    public string? LogoUrl { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    protected Club() { } // Para ORM no futuro

    public Club(
        string name,
        string city,
        string state,
        string country,
        DateTime? foundedAt = null,
        string? logoUrl = null)
    {
        ValidateName(name);
        ValidateLocation(city, state, country);
        ValidateFoundedAt(foundedAt);
        ValidateLogoUrl(logoUrl);

        IsActive = true;
        CreatedAt = DateTime.Now;
    }

    // Regras de domínio

    public void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name cannot be empty.");

        if (name.Length > 150)
            throw new ArgumentException("Club name is too long.");

        Name = name.Trim();
        Touch();
    }

    public void ValidateLocation(string city, string state, string country)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty.");
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State cannot be empty.");
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty.");

        City = city.Trim();
        State = state.Trim();
        Country = country.Trim();

        Touch();
    }

    public void ValidateFoundedAt(DateTime? foundedAt)
    {
        if (foundedAt.HasValue && foundedAt > DateTime.Now)
            throw new ArgumentException("Founded date cannot be in the future.");
        FoundedAt = foundedAt;
        Touch();
    }

    public void ValidateLogoUrl(string? logoUrl)
    {
        if (!string.IsNullOrWhiteSpace(logoUrl) &&
             !Uri.IsWellFormedUriString(logoUrl, UriKind.Absolute))
            throw new ArgumentException("Invalid logo URL.");

        LogoUrl = logoUrl;
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
    private void Touch()
    {
        UpdatedAt = DateTime.Now;
    }

}


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
    public string? City { get; private set; }

    protected Stadium() { }

    public Stadium(string name, string? city = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Stadium name cannot be empty.");

        Name = name.Trim();
        City = city?.Trim();
    }
}

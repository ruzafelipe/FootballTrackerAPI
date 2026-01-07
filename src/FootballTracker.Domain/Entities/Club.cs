using FootballTracker.Domain.Common;

namespace FootballTracker.Domain.Entities;

/*🧠 Pontos importantes

Construtor garante estado válido

protected constructor → compatível com EF depois

Sem validação exagerada (KISS)

 */

public class Club : BaseEntity
{
    public string Name { get; private set; }

    protected Club() { } // Para ORM no futuro

    public Club(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name cannot be empty.");

        Name = name.Trim();
    }
}


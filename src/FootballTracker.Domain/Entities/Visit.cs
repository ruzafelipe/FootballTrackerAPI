using FootballTracker.Domain.Common;

namespace FootballTracker.Domain.Entities;

/*Uma Visit = uma presença

Nada de fotos agora

Nada de comentários agora

Estrutura preparada para crescer

 */

public class Visit : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid MatchId { get; private set; }
    

    public User User { get; private set; }
    public Match Match { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Visit() { }

    public Visit(Guid userId, Guid matchId)
    {
        UserId = userId;
        MatchId = matchId;
        CreatedAt = DateTime.UtcNow;
    }
}

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
    public Match Match { get; private set; }

    public DateTime VisitedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Visit() { }

    public Visit(Guid userId, Guid matchId, DateTime visitedAt)
    {
        ValidateUser(userId);
        ValidateMatch(matchId);
        ValidateVisitedAt(visitedAt);

        UserId = userId;
        MatchId = matchId;
        VisitedAt = visitedAt;

        CreatedAt = DateTime.Now;
    }


    private void ValidateUser(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.");
    }

    private void ValidateMatch(Guid matchId)
    {
        if (matchId == Guid.Empty)
            throw new ArgumentException("MatchId is required.");
    }

    private void ValidateVisitedAt(DateTime visitedAt)
    {
        if (visitedAt > DateTime.Now)
            throw new ArgumentException("Visit date cannot be in the future.");        
    }

    private void Touch()
    {
        UpdatedAt = DateTime.Now;
    }
}

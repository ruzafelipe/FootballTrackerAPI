using FootballTracker.Domain.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Domain.Entities;

/*Uma entidade com estado

Com comportamento

Com regras explícitas

 */

public class Match : BaseEntity
{
    public DateTime MatchDate { get; private set; }

    public Guid StadiumId { get; private set; }
    public Guid HomeClubId { get; private set; }
    public Guid AwayClubId { get; private set; }
    public Stadium Stadium { get; private set; }
    public Club HomeClub { get; private set; }
    public Club AwayClub { get; private set; }
    public MatchStatus Status { get; private set; }

    protected Match() { }

    public Match(
        DateTime matchDate,
        Guid stadiumId,
        Guid homeClubId,
        Guid awayClubId)
    {
       // if (homeClubId == awayClubId)
         //   throw new ArgumentException("Home club and away club must be different.");

        MatchDate = matchDate;
        StadiumId = stadiumId;
        HomeClubId = homeClubId;
        AwayClubId = awayClubId;

        Status = MatchStatus.Pending;
    }

    public void Approve()
    {
        if (Status != MatchStatus.Pending)
            throw new InvalidOperationException("Only pending matches can be approved.");

        Status = MatchStatus.Approved;
    }

    public void Reject()
    {
        if (Status != MatchStatus.Pending)
            throw new InvalidOperationException("Only pending matches can be rejected.");

        Status = MatchStatus.Rejected;
    }

    public bool IsApproved()
    {
        return Status == MatchStatus.Approved;
    }
}

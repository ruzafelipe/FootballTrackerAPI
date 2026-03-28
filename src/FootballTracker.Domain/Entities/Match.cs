using FootballTracker.Domain.Common;
using FootballTracker.Domain.Enums;

namespace FootballTracker.Domain.Entities;

/*Uma entidade com estado

Com comportamento

Com regras explícitas

 */

public class Match : BaseEntity
{
    public Guid CompetitionId { get; private set; }
    public Guid StadiumId { get; private set; }
    public Guid HomeClubId { get; private set; }
    public Guid AwayClubId { get; private set; }

    public Guid CreatedByUserId { get; private set; }
    public Guid? ApprovedOrRejectedByUserId { get; private set; }

    public DateTime MatchDate { get; private set; }

    public Competition Competition { get; private set; }
    public Stadium Stadium { get; private set; }
    public Club HomeClub { get; private set; }
    public Club AwayClub { get; private set; }
    public MatchStatus Status { get; private set; }

    protected Match() { }

    public Match(
        Guid competitionId,
        Guid stadiumId,
        Guid homeClubId,
        Guid awayClubId,
        Guid createdByUserId,
        DateTime matchDate,
        Guid? approvedOrRejectedByUserId = null
        )
    {
        ValidateClubs(homeClubId, awayClubId);
        ValidateMatchDate(matchDate);

        CompetitionId = competitionId;
        StadiumId = stadiumId;
        HomeClubId = homeClubId;
        AwayClubId = awayClubId;
        CreatedByUserId = createdByUserId;
        MatchDate = matchDate;

        Status = MatchStatus.Pending;
    }

    private void ValidateClubs(Guid homeClubId, Guid awayClubId)
    {
        if (homeClubId == awayClubId)
            throw new ArgumentException("Home club and away club must be different.");
    }

    private void ValidateMatchDate(DateTime matchDate) //ISSO PRECISA MELHORAR, MAS VAI SERVIR POR ENQUANTO
    {
        if (matchDate < DateTime.Now)
            throw new ArgumentException("Match date cannot be in the past.");
    }

    public void Approve(Guid approvedByUserId)
    {
        if (Status != MatchStatus.Pending)
            throw new InvalidOperationException("Only pending matches can be approved.");

        Status = MatchStatus.Approved;
        ApprovedOrRejectedByUserId = approvedByUserId;
        SetUpdated();
    }

    public void Reject(Guid rejectByUserId)
    {
        if (Status != MatchStatus.Pending)
            throw new InvalidOperationException("Only pending matches can be rejected.");

        Status = MatchStatus.Rejected;
        ApprovedOrRejectedByUserId = rejectByUserId;
        SetUpdated();
    }

    public bool IsApproved()
    {
        return Status == MatchStatus.Approved;
    }    
}

using FootballTracker.Application.DTOs;

namespace FootballTracker.Application.UseCases.Visits.RegisterVisit;


/* 📌 Por que Command existe?

Porque:

Representa a intenção

Isola entrada de dados

Facilita testes

Evita acoplamento com API

 */

public sealed class RegisterVisitCommand
{
    public Guid UserId { get; }
    public DateTime VisitDate { get; }

    // Opção A: match já existe
    public Guid? MatchId { get; }

    // Opção B: criar match
    public RegisterMatchData? MatchData { get; }

    public RegisterVisitCommand(
        Guid userId,
        DateTime visitDate,
        Guid? matchId,
        RegisterMatchData? matchData)
    {
        UserId = userId;
        VisitDate = visitDate;
        MatchId = matchId;
        MatchData = matchData;
    }
}
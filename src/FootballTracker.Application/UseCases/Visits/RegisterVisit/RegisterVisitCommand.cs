namespace FootballTracker.Application.UseCases;


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
    public Guid MatchId { get; }    

    public RegisterVisitCommand(Guid userId, Guid matchId)
    {
        UserId = userId;
        MatchId = matchId;        
    }
}
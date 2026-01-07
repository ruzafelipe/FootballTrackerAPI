namespace FootballTracker.Domain.Enums
{

    /*🧠 Por que enum no domínio?

            Status é regra de negócio

            Não é string

            Não é número mágico

            Não fica espalhado pelo código
     
     */

    public enum MatchStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}

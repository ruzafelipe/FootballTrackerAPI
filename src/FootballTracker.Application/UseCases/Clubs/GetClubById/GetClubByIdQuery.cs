namespace FootballTracker.Application.UseCases.Clubs.GetClubById;

public sealed class GetClubByIdQuery
{
    public Guid Id { get; }
    public GetClubByIdQuery(Guid id)
    {
        Id = id;
    }
}

namespace FootballTracker.Application.UseCases.Stadiums.GetStadiumById;

public sealed class GetStadiumByIdQuery
{
    public Guid Id { get; }

    public GetStadiumByIdQuery(Guid id)
    {
        Id = id;
    }
}

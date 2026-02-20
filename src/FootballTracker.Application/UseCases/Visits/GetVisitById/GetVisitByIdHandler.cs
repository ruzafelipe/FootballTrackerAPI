using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Application.Common;
using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.UseCases.Visits.GetVisitById;

public sealed class GetVisitByIdHandler
{
    private readonly IVisitRepository _visitRepository;
    public GetVisitByIdHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    
    public async Task<Result<Visit>> HandleAsync(GetVisitByIdQuery query)
    {
        if(query.VisitId == Guid.Empty)
        {
            return Result<Visit>.Failure("Invalid visit ID");
        }

        var visit = await _visitRepository.GetByIdAsync(query.VisitId);
        if (visit is null)
        {
            return Result<Visit>.Failure("Visit not found");
        }
        
        return Result<Visit>.Success(visit);
    }

}

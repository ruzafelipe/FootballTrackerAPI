

using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly AppDbContext _context;
    public VisitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(Guid userId, Guid matchId)
    {
        return await _context.Visits.AnyAsync(v =>
            v.User.Id == userId &&
            v.Match.Id == matchId);
    }

    public async Task AddAsync(Visit visit)
    {
        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
    }

 
}
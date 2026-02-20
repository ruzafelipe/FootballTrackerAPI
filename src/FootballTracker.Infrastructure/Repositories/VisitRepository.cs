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
            v.UserId == userId &&
            v.MatchId == matchId);
    }

    public async Task AddAsync(Visit visit)
    {
        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
    }

    public async Task<Visit?> GetByIdAsync(Guid visitId)
    {
        return await IncludeMatchDetails(_context.Visits.AsNoTracking())
           .FirstOrDefaultAsync(v => v.Id == visitId);
    }

    public async Task<IReadOnlyList<Visit>> GetByUserIdAsync(Guid userId)
    {
        return await IncludeMatchDetails(_context.Visits.AsNoTracking())
            .Where(v => v.UserId == userId)
            .OrderByDescending(v => v.VisitedAt)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Visit>> GetByMatchIdAsync(Guid matchId)
    {
        return await IncludeMatchDetails(_context.Visits.AsNoTracking())
            .Where(v => v.MatchId == matchId)
            .OrderByDescending(v => v.VisitedAt)
            .ToListAsync();
    }

    private IQueryable<Visit> IncludeMatchDetails(IQueryable<Visit> query)
    {
        return query
        .Include(v => v.Match)
            .ThenInclude(m => m.Stadium)
        .Include(v => v.Match)
            .ThenInclude(m => m.HomeClub)
        .Include(v => v.Match)
            .ThenInclude(m => m.AwayClub)
        .Include(v => v.Match)
            .ThenInclude(m => m.Competition);
    }
}
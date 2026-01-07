
using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly AppDbContext _context;

    public MatchRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> ExistsAsync(Guid matchId)
    {
        return await _context.Matches.AnyAsync(m => m.Id == matchId);
    }   

    public async Task<Match?> GetByIdAsync(Guid matchId)
    {
        return await _context.Matches.FirstOrDefaultAsync(m => m.Id == matchId);
    }

    public async Task<bool> ExistsByDateAndClubsAsync(DateTime matchDate, Guid homeClubId, Guid awayClubId)
    {
       return await _context.Matches.AnyAsync(m => m.MatchDate == matchDate && m.HomeClub.Id == homeClubId && m.AwayClub.Id == awayClubId);
    }

    public async Task AddAsync(Match match)
    {
        await _context.Matches.AddAsync(match);
        await _context.SaveChangesAsync();
    }
}
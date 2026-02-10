
using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Domain.Enums;
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

    public async Task<Match?> GetByStadiumAndDateAsync(Guid stadiumId, DateTime matchDate)
    {
        return await _context.Matches.FirstOrDefaultAsync(m => m.Stadium.Id == stadiumId && m.MatchDate == matchDate);
    }

    public async Task UpdateAsync(Match match)
    {
        _context.Matches.Update(match);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Match>> GetAllByStatusesAsync(IReadOnlyCollection<MatchStatus> statuses)
    {
        return await _context.Matches
            .Where(m => statuses.Contains(m.Status))
            .ToListAsync();
    }
}
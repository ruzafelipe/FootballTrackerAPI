using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Repositories;
public class CompetitionRepository : ICompetitionRepository

{
    private readonly AppDbContext _context;

    public CompetitionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Competition competition)
    {
        await _context.Competitions.AddAsync(competition);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> ExistsByIdAsync(Guid competitionId)
    {
        return await _context.Competitions
            .AnyAsync(c => c.Id == competitionId);
    }
    public async Task<bool> ExistsByNameAndSeasonAsync(string competitionName, string season)
    {
        return await _context.Competitions
            .AnyAsync(c => c.Name == competitionName && c.Season == season);
    }
    public async Task<Competition?> GetByIdAsync(Guid competitionId)
    {
        return await _context.Competitions
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == competitionId);
    }

    public async Task UpdateAsync(Competition competition)
    {
        _context.Competitions.Update(competition);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Competition>> GetAllActiveAsync(bool onlyActive = true)
    {
        var query = _context.Competitions.AsQueryable();

        if(onlyActive)
        {
            query = query.Where(c => c.IsActive);
        }
        return await query
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    

    
}

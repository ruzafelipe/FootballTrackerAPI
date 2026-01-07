using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Repositories;

public class ClubRepository : IClubRepository
{
    private readonly AppDbContext _context;

    public ClubRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Club club)
    {
        await _context.Clubs.AddAsync(club);
        await _context.SaveChangesAsync();
    }  

    public async Task<bool> ExistsByNameAsync(string clubName)
    {
        return await _context.Clubs.AnyAsync(c => c.Name == clubName);
    }

    public async Task<Club?> GetByIdAsync(Guid clubId)
    {
        return await _context.Clubs.FindAsync(clubId);
    }

    public async Task<bool> ExistsByIdAsync(Guid clubId)
    {
        return await _context.Clubs.AnyAsync(c => c.Id == clubId);
    }
}
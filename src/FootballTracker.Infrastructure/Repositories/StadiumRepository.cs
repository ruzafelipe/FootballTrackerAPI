using FootballTracker.Application.Abstractions.Repositories;
using FootballTracker.Domain.Entities;
using FootballTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTracker.Infrastructure.Repositories;

public class StadiumRepository : IStadiumRepository
{

    private readonly AppDbContext _context;

    public StadiumRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Stadium stadium)
    {
        await _context.Stadiums.AddAsync(stadium);
        await _context.SaveChangesAsync(); 
    }   

    public async Task<bool> ExistsByNameAsync(string stadiumName)
    {
        return await _context.Stadiums.AnyAsync(s => s.Name == stadiumName);
    }

    public async Task<Stadium?> GetByIdAsync(Guid stadiumId)
    {
        return await _context.Stadiums
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == stadiumId); //chat gpt sugeriu o asnotracking aqui pq é uma consulta de leitura. Veremos se faz diferença mais pra frente e se colocaremos em outras consultas de leitura
    }

    public async Task<bool> ExistsById(Guid stadiumId)
    {
        return await _context.Stadiums.AnyAsync(s => s.Id == stadiumId);
    }

    public async Task UpdateAsync(Stadium stadium)
    {
        _context.Stadiums.Update(stadium);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Stadium>> GetAllActiveAsync(bool onlyActive = true)
    {
        var query = _context.Stadiums.AsQueryable();

        if(onlyActive)
        {
            query = query.Where(s => s.IsActive);
        }

        return await query
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Stadium>> GetAllAsync()
    {
        return await _context.Stadiums
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
}
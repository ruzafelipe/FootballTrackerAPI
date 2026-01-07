using FootballTracker.Domain.Entities;

namespace FootballTracker.Application.Abstractions.Repositories;


/*📌 Por que repositórios ficam na Application?

Porque:

Application define o que precisa

Infrastructure decide como implementar

Isso inverte a dependência (DIP – SOLID)

 */

public interface IUserRepository
{
    Task<bool> ExistsAsync(Guid userId);

    Task<User?> GetByIdAsync(Guid userId);

    Task AddAsync(User user);
}

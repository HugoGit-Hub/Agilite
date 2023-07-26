using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
    public Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken);
}

public class UserRepository : IUserRepository
{
    private readonly AgiliteContext _context;

    public UserRepository(AgiliteContext context)
        => _context = context;

    public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken)
        => await _context.Users.FirstAsync(user => user.EmailUser == email, cancellationToken);

    public async Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken)
        => await _context.Teams
            .Where(e => e.Users.Any(user => user.IdUser == idUser))
            .ToListAsync(cancellationToken);
}
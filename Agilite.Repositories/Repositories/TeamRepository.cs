using Agilite.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface ITeamRepository
{
    public Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken);
}

public class TeamRepository : ITeamRepository
{
    private readonly AgiliteContext _context;

    public TeamRepository(AgiliteContext context) 
        =>   _context = context;

    public async Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken)
        => await _context.Teams
            .Where(e => e.Users.Any(user => user.IdUser == idUser))
            .ToListAsync(cancellationToken);
}
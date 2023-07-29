using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface ITeamRepository
{
    public Task<Team> CreateTeamUser(int idTeam, int idUser, CancellationToken cancellationToken);
    public Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken);
}

public class TeamRepository : ITeamRepository
{
    private readonly AgiliteContext _context;

    public TeamRepository(AgiliteContext context) 
        =>   _context = context;

    public async Task<Team> CreateTeamUser(int idTeam, int idUser, CancellationToken cancellationToken)
    {
        var team = await _context.Teams.SingleOrDefaultAsync(team => team.IdTeam == idTeam, cancellationToken);
        var user = await _context.Users.SingleOrDefaultAsync(user => user.IdUser == idUser, cancellationToken);
        if (user != null) team?.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return await _context.Teams.Where(e => e.IdTeam == idTeam).SingleAsync(cancellationToken);
    }

    public async Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken)
        => await _context.Projects
            .Where(e => e.IdTeamNavigation.IdTeam == idTeam)
            .ToListAsync(cancellationToken);
}
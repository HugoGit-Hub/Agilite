using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IProjectRepository
{
    public Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken);
}

public class ProjectRepository : IProjectRepository
{
    private readonly AgiliteContext _context;

    public ProjectRepository(AgiliteContext context)
        => _context = context;

    public async Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken)
        => await _context.Projects
            .Where(e => e.IdTeamNavigation.IdTeam == idTeam)
            .ToListAsync(cancellationToken);
}
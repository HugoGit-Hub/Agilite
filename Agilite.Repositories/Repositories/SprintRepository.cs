using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface ISprintRepository
{
    public Task<List<Sprint>> GetAllSprintsOfOneProject(int idProject, CancellationToken cancellationToken);
}

public class SprintRepository : ISprintRepository
{
    private readonly AgiliteContext _context;

    public SprintRepository(AgiliteContext context)
        => _context = context;

    public async Task<List<Sprint>> GetAllSprintsOfOneProject(int idProject, CancellationToken cancellationToken)
        => await _context.Projects
            .Where(e => e.IdProject == idProject)
            .SelectMany(e => e.Sprints)
            .ToListAsync(cancellationToken);
}
using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IProjectTypeRepository
{
    public Task<IEnumerable<ProjectType>> GetAllProjectType(CancellationToken cancellationToken);
}

public class ProjectTypeRepository : IProjectTypeRepository
{
    private readonly AgiliteContext _context;

    public ProjectTypeRepository(AgiliteContext context)
        => _context = context;

    public async Task<IEnumerable<ProjectType>> GetAllProjectType(CancellationToken cancellationToken)
        => await _context.ProjectTypes.ToListAsync(cancellationToken);
}

using Agilite.Entities;
using Agilite.UnitOfWork;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface ISprintRepository
{
    public Task<Sprint> Create(Sprint sprint, CancellationToken cancellationToken);

    public Task<List<Sprint>> GetAllSprintsOfOneProject(int idProject, CancellationToken cancellationToken);

    public Task<int?> GetLastSprintNumber(int idProject, CancellationToken cancellationToken);
}

public class SprintRepository : ISprintRepository
{
    private readonly AgiliteContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public SprintRepository(AgiliteContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task<Sprint> Create(Sprint sprint, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.GetRepository<Sprint>().Create(sprint);
        await _unitOfWork.SaveAsync(cancellationToken);
        
        return result;
    }

    public async Task<List<Sprint>> GetAllSprintsOfOneProject(int idProject, CancellationToken cancellationToken)
        => await _context.Projects
            .Where(e => e.IdProject == idProject)
            .SelectMany(e => e.Sprints)
            .ToListAsync(cancellationToken);

    public async Task<int?> GetLastSprintNumber(int idProject, CancellationToken cancellationToken)
    {
        var result = await _context.Sprints
            .Where(e => e.FkProject == idProject)
            .MaxAsync(e => (int?)e.NumberSprint, cancellationToken);

        return result;
    }
}
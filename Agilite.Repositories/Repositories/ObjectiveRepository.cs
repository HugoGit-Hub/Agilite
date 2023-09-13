using Agilite.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IObjectiveRepository
{
    public Task<IEnumerable<Objective>> GetAllObjectivesOfOneSprint(int id);
}

public class ObjectiveRepository : IObjectiveRepository
{
    private readonly AgiliteContext _context;

    public ObjectiveRepository(AgiliteContext context)
        => _context = context;

    public async Task<IEnumerable<Objective>> GetAllObjectivesOfOneSprint(int id)
    {
        var result = await _context.Objectives
            .Where(e => e.Sprints.Any(sprint => sprint.IdSprint == id))
            .ToListAsync();

        return result;
    }
}
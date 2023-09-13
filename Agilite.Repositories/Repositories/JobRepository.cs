using Agilite.Entities;
using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IJobRepository
{
    public Task<IEnumerable<Job>> GetAllJobsOfOneObjective(int id, CancellationToken cancellationToken);
}

public class JobRepository : IJobRepository
{
    private readonly AgiliteContext _context;

    public JobRepository(AgiliteContext context)
        => _context = context;

    public async Task<IEnumerable<Job>> GetAllJobsOfOneObjective(int id, CancellationToken cancellationToken)
        => await _context.Jobs
            .Where(x => x.Objectives.Any(objective => objective.IdObjective == id))
            .ToListAsync(cancellationToken);
}
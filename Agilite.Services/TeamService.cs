using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface ITeamService
{
    public Task<Team> CreateTeamUser(int idUse, int idTeam, CancellationToken cancellationToken);
    public Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken);
}

public class TeamService: ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
        => _teamRepository = teamRepository;

    public async Task<Team> CreateTeamUser(int idUse, int idTeam, CancellationToken cancellationToken)
        => await _teamRepository.CreateTeamUser(idUse, idTeam, cancellationToken);

    public async Task<IEnumerable<Project>> GetAllProjectsOfOneTeam(int idTeam, CancellationToken cancellationToken)
        => await _teamRepository.GetAllProjectsOfOneTeam(idTeam, cancellationToken);
}
using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface ITeamService
{
    public Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken);
}

public class TeamService: ITeamService
{
    private readonly ITeamRepository _repository;

    public TeamService(ITeamRepository repository)
        => _repository = repository;

    public async Task<IEnumerable<Team>> GetAllTeamsOfOneUser(int idUser, CancellationToken cancellationToken)
        => await _repository.GetAllTeamsOfOneUser(idUser, cancellationToken);
}
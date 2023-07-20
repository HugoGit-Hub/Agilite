using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;

namespace Agilite.Services;

public interface IUserTeamService
{
    public IEnumerable<UserTeam> GetUserTeamByUserId(int id);
}

public class UserTeamService : IUserTeamService
{
    private readonly IUserTeamRepository _userTeamRepository;

    public UserTeamService(IUserTeamRepository userTeamRepository)
    {
        _userTeamRepository = userTeamRepository;
    }

    public IEnumerable<UserTeam> GetUserTeamByUserId(int id)
    {
        return _userTeamRepository.GetUserTeamByUserId(id);
    }
}
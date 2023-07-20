using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;

namespace Agilite.Repositories.Repositories;

public interface IUserTeamRepository
{
    public IEnumerable<UserTeam> GetUserTeamByUserId(int id);
}

public class UserTeamRepository : IUserTeamRepository
{
    private readonly AgiliteContext _context;

    public UserTeamRepository(AgiliteContext context)
    {
        _context = context;
    }

    public IEnumerable<UserTeam> GetUserTeamByUserId(int id)
    {
        return _context.UserTeams
            .Where(userTeam => userTeam.IdUser == id)
            .ToList();
    }
}
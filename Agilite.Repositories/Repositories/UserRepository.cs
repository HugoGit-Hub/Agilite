using Agilite.Entities.Entities;
using Agilite.UnitOfWork.Context;

namespace Agilite.Repositories.Repositories;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
}

public class UserRepository : IUserRepository
{
    private readonly AgiliteContext _context;

    public UserRepository(AgiliteContext context)
    {
        _context = context;
    }

    public User GetUserByEmail(string email)
    {
        return _context.Users
            .First(user => user.EmailUser == email);
    }
}
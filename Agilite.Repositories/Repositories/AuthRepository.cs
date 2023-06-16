using Agilite.UnitOfWork;
using Agilite.UnitOfWork.IRepositories;

namespace Agilite.Repositories.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AgiliteContext _context;

    public AuthRepository(AgiliteContext context)
    {
        _context = context;
    }

    public bool IsCredentialsValid(string email, string password)
    {
        return _context.Users
            .Any(user => user.EmailUser == email && user.PasswordUser == password);
    }

    public byte[]? GetSalt(string email)
    {
        return _context.Users
            .Where(user => user.EmailUser == email)
            .Select(user => user.SaltUser)
            .SingleOrDefault();
    }
}

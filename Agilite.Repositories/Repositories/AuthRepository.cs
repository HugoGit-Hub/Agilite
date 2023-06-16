using Agilite.UnitOfWork.Context;

namespace Agilite.Repositories.Repositories;

public interface IAuthRepository
{
    public bool IsCredentialsValid(string email, string password);

    public byte[]? GetSalt(string email);
}

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

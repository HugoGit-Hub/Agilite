using Agilite.UnitOfWork.Context;

namespace Agilite.Repositories.Repositories;

public interface IAuthenticationRepository
{
    public bool IsCredentialsValid(string email, string password);

    public byte[]? GetSalt(string email);
}

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly AgiliteContext _context;

    public AuthenticationRepository(AgiliteContext context)
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

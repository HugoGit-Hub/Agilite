using Agilite.UnitOfWork.Context;
using Microsoft.EntityFrameworkCore;

namespace Agilite.Repositories.Repositories;

public interface IAuthenticationRepository
{
    public Task<bool> IsCredentialsValid(string email, string password, CancellationToken cancellationToken);

    public byte[]? GetSalt(string email);
}

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly AgiliteContext _context;

    public AuthenticationRepository(AgiliteContext context)
        => _context = context;

    public async Task<bool> IsCredentialsValid(string email, string password, CancellationToken cancellationToken)
    => await _context.Users
            .AnyAsync(user => user.EmailUser == email && user.PasswordUser == password, cancellationToken);

    public byte[]? GetSalt(string email)
        => _context.Users
            .Where(user => user.EmailUser == email)
            .Select(user => user.SaltUser)
            .SingleOrDefault();
}

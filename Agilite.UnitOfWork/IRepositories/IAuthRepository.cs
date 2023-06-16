namespace Agilite.UnitOfWork.IRepositories;

public interface IAuthRepository
{
    public bool IsCredentialsValid(string email, string password);

    public byte[]? GetSalt(string email);
}

using Agilite.Entities.Entities;
using Agilite.Services.Managers;
using Agilite.UnitOfWork;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Agilite.Services;

public interface IUserSerice
{
    public User CreateUser(User user);
}

public class UserService : IUserSerice
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public User CreateUser(User user)
    {
        var salt = GenerateSalt();
        var encryptedSalt = AuthenticationManager.EncryptData(salt, _configuration.GetSection("AppSettings:EncryptDecryptKey").Value!);
        var hashedPassword = AuthenticationManager.HashPasswordSaltCombination(user.PasswordUser, salt);

        var createUser = new User
        {
            IdUser = user.IdUser,
            FirstNameUser = user.FirstNameUser,
            LastNameUser = user.LastNameUser,
            EmailUser = user.EmailUser,
            PasswordUser = hashedPassword,
            SaltUser = encryptedSalt,
            DateCreationUser = user.DateCreationUser,
            AgeUser = user.AgeUser,
        };

        var created = _unitOfWork.GetRepository<User>().Create(createUser);
        _unitOfWork.Save();
        return created;
    }

    private static string GenerateSalt()
    {
        var saltByte = new byte[16];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltByte);
        return Convert.ToBase64String(saltByte);
    }
}
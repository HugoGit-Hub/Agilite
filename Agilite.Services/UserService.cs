using Agilite.Entities.Entities;
using Agilite.Repositories.Repositories;
using Agilite.Services.Managers;
using Agilite.UnitOfWork;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace Agilite.Services;

public interface IUserService
{
    public User CreateUser(User user);
    public User GetUserByEmail(string email);
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public UserService(IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public User CreateUser(User user)
    {
        var salt = GenerateSalt();
        var encryptedSalt = AuthenticationManager.EncryptData(salt, _configuration.GetSection("AppSettings:EncryptDecryptKey").Value!);
        var hashedPassword = AuthenticationManager.HashPasswordSaltCombination(user.PasswordUser, salt);

        user.PasswordUser = hashedPassword;
        user.SaltUser = encryptedSalt;


        var created = _unitOfWork.GetRepository<User>().Create(user);
        _unitOfWork.Save();

        return created;
    }

    public User GetUserByEmail(string email)
        => _userRepository.GetUserByEmail(email);

    private static string GenerateSalt()
    {
        var saltByte = new byte[16];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltByte);
        return Convert.ToBase64String(saltByte);
    }
}
using Agilite.Services.Exceptions;
using Agilite.Services.Managers;
using Agilite.UnitOfWork.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agilite.Services;

public interface IAuthService
{
    public string Login(string email, string password);
}

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration, IAuthRepository authRepository)
    {
        _configuration = configuration;
        _authRepository = authRepository;
    }

    public string Login(string email, string password)
    {
        var encryptedSalt = _authRepository.GetSalt(email) ?? throw new WrongCredentialsException();
        var decryptedSalt = AuthManager.DecryptData(encryptedSalt, _configuration.GetSection("AppSettings:EncryptDecryptKey").Value!);
        var hashedAndSaltPassword = AuthManager.HashPasswordSaltCombination(password, decryptedSalt);
        _ = _authRepository.IsCredentialsValid(email, hashedAndSaltPassword) ? true : throw new WrongCredentialsException();

        return GenerateToken(email);
    }

    private string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}

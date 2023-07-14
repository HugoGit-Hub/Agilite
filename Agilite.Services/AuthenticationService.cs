using Agilite.Repositories.Repositories;
using Agilite.Services.Exceptions;
using Agilite.Services.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agilite.Services;

public interface IAuthenticationService
{
    public string Login(string email, string password);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationService(IConfiguration configuration, IAuthenticationRepository authenticationRepository)
    {
        _configuration = configuration;
        _authenticationRepository = authenticationRepository;
    }

    public string Login(string email, string password)
    {
        var encryptedSalt = _authenticationRepository.GetSalt(email) ?? throw new WrongCredentialsException();
        var decryptedSalt = AuthenticationManager.DecryptData(encryptedSalt, _configuration.GetSection("AppSettings:EncryptDecryptKey").Value!);
        var hashedAndSaltPassword = AuthenticationManager.HashPasswordSaltCombination(password, decryptedSalt);
        _ = _authenticationRepository.IsCredentialsValid(email, hashedAndSaltPassword) ? true : throw new WrongCredentialsException();

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

using Agilite.Entities;
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
    public Task<string> Login(string email, string password, CancellationToken cancellationToken);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationService(
        IAuthenticationRepository authenticationRepository,
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _authenticationRepository = authenticationRepository;
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> Login(string email, string password, CancellationToken cancellationToken)
    {
        var encryptedSalt = _authenticationRepository.GetSalt(email) ?? throw new WrongCredentialsException();
        var decryptedSalt = AuthenticationManager.DecryptData(encryptedSalt, _configuration.GetSection("AppSettings:EncryptDecryptKey").Value!);
        var hashedAndSaltPassword = AuthenticationManager.HashPasswordSaltCombination(password, decryptedSalt);
        var isCredantialsValide = await _authenticationRepository.IsCredentialsValid(email, hashedAndSaltPassword, cancellationToken);

        if (!isCredantialsValide)
        {
            throw new WrongCredentialsException();
        }

        return GenerateToken(await _userRepository.GetUserByEmail(email, cancellationToken));
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenKey").Value!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("sub", user.IdUser.ToString()),
                new Claim(ClaimTypes.Email, user.EmailUser),
                new Claim(ClaimTypes.Name, user.FirstNameUser),
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}

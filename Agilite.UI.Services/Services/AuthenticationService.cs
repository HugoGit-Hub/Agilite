using Agilite.DataTransferObject;
using Agilite.UI.Services.Refit;

namespace Agilite.UI.Services.Services;

public interface IAuthenticationService
{
    public Task<string> Login(LoginDto loginDto);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRefit _authenticationRefitService;

    public AuthenticationService(IAuthenticationRefit authenticationRefitService)
    {
        _authenticationRefitService = authenticationRefitService;
    }

    public Task<string> Login(LoginDto loginDto)
        => Task.FromResult(_authenticationRefitService.Login(loginDto).Result);
}
using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services.Refit;

namespace Agilite.UI.Services.Services;

public interface IAuthenticationService
{
    public Task<string> Login(LoginDto loginDto);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationRefitService _authenticationRefitService;

    public AuthenticationService(IAuthenticationRefitService authenticationRefitService)
    {
        _authenticationRefitService = authenticationRefitService;
    }

    public Task<string> Login(LoginDto loginDto)
        => Task.FromResult(_authenticationRefitService.Login(loginDto).Result);
}
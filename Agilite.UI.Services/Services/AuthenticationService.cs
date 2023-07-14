using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services.Refit;

namespace Agilite.UI.Services.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthenticationService _authRefitService;

    public AuthenticationService(IAuthenticationService authRefitService)
        => _authRefitService = authRefitService;

    public Task<string> Login(LoginDto loginDto)
        => Task.FromResult(_authRefitService.Login(loginDto).Result);
}
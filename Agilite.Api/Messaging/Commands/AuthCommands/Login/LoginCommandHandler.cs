using Agilite.Services;
using MediatR;

namespace Agilite.Api.Messaging.Commands.AuthCommands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = _authService.Login(request.Login.Email, request.Login.Password);
        return Task.FromResult(token);
    }
}

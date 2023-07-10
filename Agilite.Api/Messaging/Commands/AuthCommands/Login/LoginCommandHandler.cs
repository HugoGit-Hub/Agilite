using Agilite.Services;
using MediatR;

namespace Agilite.Api.Messaging.Commands.AuthCommands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthService _authenticationService;

    public LoginCommandHandler(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = _authenticationService.Login(request.Login.Email, request.Login.Password);
        return Task.FromResult(token);
    }
}

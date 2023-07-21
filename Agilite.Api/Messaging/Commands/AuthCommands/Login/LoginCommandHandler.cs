using Agilite.Services;
using MediatR;

namespace Agilite.Api.Messaging.Commands.AuthCommands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        => await _authenticationService.Login(request.Login.EmailUser, request.Login.PasswordUser, cancellationToken);
}

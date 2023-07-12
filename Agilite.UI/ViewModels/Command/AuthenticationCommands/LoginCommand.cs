using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using System;
using System.Windows;

namespace Agilite.UI.ViewModels.Command.AuthenticationCommands;

public class LoginCommand : RelayCommand
{
    private readonly LoginModel _loginModel;
    private readonly AuthenticationService _authenticationService;

    public LoginCommand(
        LoginModel loginModel,
        AuthenticationService authenticationService)
    {
        _loginModel = loginModel;
        _authenticationService = authenticationService;
    }

    public override void Execute(object? parameter)
    {
        var login = new LoginModel
        {
            EmailUser = _loginModel.EmailUser,
            PasswordUser = _loginModel.PasswordUser
        };

        try
        {
            _authenticationService.Login(login);
            OnCanExecutedChanged();
        }
        catch (UnauthorizedAccessException)
        {
        }
        catch (Exception e)
        {
            var _ = $"ERROR: {e.Message}";
        }
    }
}
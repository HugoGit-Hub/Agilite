using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using Agilite.UI.ViewModels.Command.AuthenticationCommands;
using Agilite.UI.Views;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class LoginViewModel : ObservableObject
{
    private readonly LoginModel _model;

    public LoginViewModel(
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _model = new LoginModel();
        LoginCommand = new LoginCommand(_model, authenticationService, mapper);
        LoginCommand.CanExecuteChanged += LoginSucceed!;
    }

    public ICommand LoginCommand { get; }

    public string Email
    {
        get => _model.EmailUser;
        set
        {
            _model.EmailUser = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _model.PasswordUser;
        set
        {
            _model.PasswordUser = value;
            OnPropertyChanged();
        }
    }

    private static void LoginSucceed(object sender, EventArgs e)
    {
        var customWindow = new MainWindow();
        customWindow.Show();
        
        foreach (Window window in Application.Current.Windows)
        {
            if (window is not LoginView) continue;
            window.Close();
            break;
        }
    }
}
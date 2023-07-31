using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using Agilite.UI.Views;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class LoginViewModel : ObservableObject
{
    private readonly LoginModel _model;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
    private readonly ICommand _loginCommand;

    public ICommand LoginCommand
    {
        get => _loginCommand;
        private init => SetProperty(ref _loginCommand, value);
    }

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

    public LoginViewModel(
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
        _model = new LoginModel();
        LoginCommand = new RelayCommand(Login);
    }

    private void Login()
    {
        var login = new LoginModel
        {
            EmailUser = Email,
            PasswordUser = Password
        };

        try
        {
            var token = _authenticationService.Login(_mapper.Map<LoginDto>(login)).Result;
            TokenService.StoreTokenInCache(token);
            LoginSucceed();
        }
        catch (UnauthorizedAccessException)
        {
        }
        catch (Exception e)
        {
            var _ = $"ERROR: {e.Message}";
        }
    }

    private static void LoginSucceed()
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
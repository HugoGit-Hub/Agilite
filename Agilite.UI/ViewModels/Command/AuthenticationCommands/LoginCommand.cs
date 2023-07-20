﻿using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using AutoMapper;
using System;

namespace Agilite.UI.ViewModels.Command.AuthenticationCommands;

public class LoginCommand : RelayCommand
{
    private readonly LoginModel _loginModel;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public LoginCommand(
        LoginModel loginModel,
        IAuthenticationService authenticationService,
        IMapper mapper)
    {
        _loginModel = loginModel;
        _authenticationService = authenticationService;
        _mapper = mapper;
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
            var token = _authenticationService.Login(_mapper.Map<LoginDto>(login)).Result;
            TokenService.StoreTokenInCache(token);
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
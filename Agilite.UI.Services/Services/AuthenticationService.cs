using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public class AuthenticationService
{
    private readonly IAuthenticationRefitService _authRefitService;
    private readonly IMapper _mapper;

    public AuthenticationService(
        IAuthenticationRefitService authRefitService,
        IMapper mapper)
    {
        _authRefitService = authRefitService;
        _mapper = mapper;
    }

    public string Login(LoginModel loginModel)
    {   
        var loginDto = _mapper.Map<LoginDto>(loginModel);
        return _authRefitService.Login(loginDto).Result;
    }
}
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.ViewModels;

public interface IDefaultViewModel
{
    public UserModel User { get; }
}

public class DefaultViewModel : ViewModelBase, IDefaultViewModel
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    private const string EMAIL_CLAIM = "email"; 

    public DefaultViewModel(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
        LoadUser(TokenService.GetClaimValue(EMAIL_CLAIM));
    }

    public UserModel User { get; set; } = new();

    private void LoadUser(string email)
    {
        var user = _userService.GetUserByEmail(email).Result;
        User = _mapper.Map<UserModel>(user);
    }
}
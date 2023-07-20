using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services.Refit;

namespace Agilite.UI.Services.Services;

public interface IUserService
{
    public Task<UserDto> Get(int id);
    public Task<UserDto> GetUserByEmail(string email);
}

public class UserService : IUserService
{
    private readonly IUserRefitService _userRefitService;

    public UserService(IUserRefitService userRefitService)
    {
        _userRefitService = userRefitService;
    }

    public Task<UserDto> Get(int id)
        => _userRefitService.Get(id);

    public Task<UserDto> GetUserByEmail(string email)
        => _userRefitService.GetUserByEmail(email);
}

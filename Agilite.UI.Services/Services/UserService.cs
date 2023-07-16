using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Services.Services.Refit;

namespace Agilite.UI.Services.Services;

public class UserService : IUserService
{
    private readonly IUserService _userService;

    public UserService(IUserService userService)
        => _userService = userService;

    public Task<UserDto> Create(UserDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Update(UserDto entity)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<UserDto>> IUserService.GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Get(int id)
        => _userService.Get(id);

    public Task<UserDto> GetUserByEmail(string email)
        => _userService.GetUserByEmail(email);

    public Task<UserDto> Delete(UserDto entity)
    {
        throw new NotImplementedException();
    }
}

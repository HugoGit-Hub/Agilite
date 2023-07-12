using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserService(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public Task<IEnumerable<UserModel>> GetAll()
    {
        var getAll = _userService.GetAll().Result;
        return Task.FromResult(_mapper.Map<IEnumerable<UserModel>>(getAll));
    }
}

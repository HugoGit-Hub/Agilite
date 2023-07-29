using Agilite.DataTransferObject.DTOs;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services.Refit;
using AutoMapper;

namespace Agilite.UI.Services.Services;

public interface IUserService
{
    public Task<UserDto> Get(int id);
    public Task<UserDto> GetUserByEmail(string email);
    public Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id);
}

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRefitService _refitService;

    public UserService(IMapper mapper, IUserRefitService refitService)
    {
        _mapper = mapper;
        _refitService = refitService;
    }

    public Task<UserDto> Get(int id)
        => _refitService.Get(id);

    public Task<UserDto> GetUserByEmail(string email)
        => _refitService.GetUserByEmail(email);

    public async Task<IEnumerable<TeamModel>> GetAllTeamsOfOneUser(int id)
    {
        var result = await _refitService.GetAllTeamsOfOneUser(id);
        return _mapper.Map<IEnumerable<TeamModel>>(result);
    }
}

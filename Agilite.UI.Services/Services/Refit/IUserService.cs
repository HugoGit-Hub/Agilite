using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IUserService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_USER)]
    public Task<UserDto> Create(UserDto entity);

    [Put(EndPointConstantes.UPDATE_USER)]
    public Task<UserDto> Update(UserDto entity);

    [Get(EndPointConstantes.GET_ALL_USERS)]
    public Task<IEnumerable<UserDto>> GetAll();

    [Get(EndPointConstantes.GET_USER)]
    public Task<UserDto> Get(int id);

    [Get(EndPointConstantes.GET_USER_BY_EMAIL)]
    public Task<UserDto> GetUserByEmail(string email);

    [Delete(EndPointConstantes.DELETE_USER)]
    public Task<UserDto> Delete(UserDto entity);
}
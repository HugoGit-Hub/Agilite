using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IUserService : IBaseRefitClient
{
    [Post(EndPointConstantes.CREATE_USER)]
    public UserDto Create(UserDto entity);

    [Put(EndPointConstantes.UPDATE_USER)]
    public UserDto Update(UserDto entity);

    [Get(EndPointConstantes.GET_ALL_USERS)]
    public Task<IEnumerable<UserDto>> GetAll();

    [Get(EndPointConstantes.GET_USER)]
    public UserDto Get(int id);

    [Delete(EndPointConstantes.DELETE_USER)]
    public UserDto Delete(UserDto entity);
}
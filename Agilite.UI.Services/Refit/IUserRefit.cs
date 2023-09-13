using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IUserRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.CreateUser)]
    public Task<UserDto> Create(UserDto entity);

    [Put(EndPointConstantes.UpdateUser)]
    public Task<UserDto> Update(UserDto entity);

    [Get(EndPointConstantes.AllUsers)]
    public Task<IEnumerable<UserDto>> GetAll();

    [Get(EndPointConstantes.User)]
    public Task<UserDto> Get(int id);

    [Get(EndPointConstantes.UserByEmail)]
    public Task<UserDto> GetUserByEmail(string email);

    [Delete(EndPointConstantes.DeleteUser)]
    public Task<UserDto> Delete(UserDto entity);
}
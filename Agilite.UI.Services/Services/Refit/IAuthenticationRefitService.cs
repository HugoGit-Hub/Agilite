using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IAuthenticationRefitService : IBaseRefitClient
{
    [Post(EndPointConstantes.LOGIN)]
    public Task<string> Login(LoginDto loginDto);
}
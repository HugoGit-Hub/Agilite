using Agilite.DataTransferObject.DTOs;
using Refit;

namespace Agilite.UI.Services.Services.Refit;

public interface IAuthenticationService : IBaseRefitClient
{
    [Post(EndPointConstantes.LOGIN)]
    public Task<string> Login(LoginDto loginDto);
}
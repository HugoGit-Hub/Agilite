using Agilite.DataTransferObject;
using Refit;

namespace Agilite.UI.Services.Refit;

public interface IAuthenticationRefit : IBaseRefitClient
{
    [Post(EndPointConstantes.Login)]
    public Task<string> Login(LoginDto loginDto);
}
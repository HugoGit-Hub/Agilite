using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Agilite.UI.ViewModels;

public class DefaultViewModel : ObservableObject
{
    private const string UNIQUE_NAME_CLAIM = "unique_name";

    public DefaultViewModel()
    {
        UserName = TokenService.GetClaimValue(UNIQUE_NAME_CLAIM);
    }

    public string UserName { get; }
}
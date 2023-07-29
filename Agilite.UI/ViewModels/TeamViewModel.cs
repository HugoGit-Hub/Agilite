using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Agilite.UI.ViewModels;

public class TeamViewModel : ViewModelBase
{
    private const string ID_USER = "sub";

    private readonly IUserService _service;

    public ObservableCollection<TeamModel> Teams { get; } = new();

    public TeamViewModel(IUserService service)
    {
        _service = service;
        GetAllTeamsOfOneUser(int.Parse(TokenService.GetClaimValue(ID_USER)));
    }

    private async void GetAllTeamsOfOneUser(int id)
    {
        var teams = await _service.GetAllTeamsOfOneUser(id);

        foreach (var team in teams)
        {
            Teams.Add(team);
        }
    }
}
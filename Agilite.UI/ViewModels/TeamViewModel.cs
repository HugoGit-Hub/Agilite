using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Agilite.UI.ViewModels;

public class TeamViewModel : ViewModelBase
{
    private const string ID_USER = "sub";

    private readonly ITeamService _teamService;

    public ObservableCollection<TeamModel> Teams { get; } = new();

    public TeamViewModel(ITeamService teamService)
    {
        _teamService = teamService;
        GetAllTeamsOfOneUser(int.Parse(TokenService.GetClaimValue(ID_USER)));
    }

    private async void GetAllTeamsOfOneUser(int id)
    {
        var teams = await _teamService.GetAllTeamsOfOneUser(id);

        foreach (var team in teams)
        {
            Teams.Add(team);
        }
    }
}
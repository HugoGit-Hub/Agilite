using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Agilite.UI.ViewModels;

public class DefaultViewModel : ObservableObject
{
    private const string UNIQUE_NAME_CLAIM = "unique_name";
    private const string ID_USER = "sub";

    private readonly ITeamService _teamService;
    private readonly int _idUser = int.Parse(TokenService.GetClaimValue(ID_USER));

    public DefaultViewModel(ITeamService teamService)
    {
        _teamService = teamService;

        LoadTeamsAsync();

        UserName = TokenService.GetClaimValue(UNIQUE_NAME_CLAIM);
    }

    public ObservableCollection<TeamModel> Teams { get; } = new();

    public string UserName { get; }

    private async void LoadTeamsAsync()
    {
        var teams = await _teamService.GetAllTeamsOfOneUser(_idUser);

        Teams.Clear();

        foreach (var team in teams)
        {
            Teams.Add(team);
        }
    }
}
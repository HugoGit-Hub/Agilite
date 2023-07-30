using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class TeamViewModel : ObservableObject
{
    private const string ID_USER = "sub";

    private readonly ITeamService _teamService;
    private readonly IProjectService _projectService;
    private readonly ICommand _getAllProjectsOfOneTeamCommand;

    public ICommand GetAllProjectsOfOneTeamCommand
    {
        get => _getAllProjectsOfOneTeamCommand;
        private init => SetProperty(ref _getAllProjectsOfOneTeamCommand, value);
    }

    public ObservableCollection<TeamModel> Teams { get; } = new();
    public ObservableCollection<ProjectModel> Projects { get; } = new();

    public TeamViewModel(ITeamService teamService, IProjectService projectService)
    {
        _teamService = teamService;
        _projectService = projectService;
        GetAllTeamsOfOneUser(int.Parse(TokenService.GetClaimValue(ID_USER)));
        GetAllProjectsOfOneTeamCommand = new RelayCommand<int>(GetAllProjectsOfOneTeam);
    }

    private async void GetAllTeamsOfOneUser(int id)
    {
        var teams = await _teamService.GetAllTeamsOfOneUser(id);

        foreach (var team in teams)
        {
            Teams.Add(team);
        }
    }

    private async void GetAllProjectsOfOneTeam(int id)
    {
        var projects = await _projectService.GetAllProjectsOfOneTeam(id);

        Projects.Clear();

        foreach (var project in projects)
        {
            Projects.Add(project);
        }
    }
}
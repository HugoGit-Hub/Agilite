using Agilite.UI.Message;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class TeamViewModel : ObservableObject
{
    private const string ID_USER = "sub";

    private readonly ITeamService _teamService;
    private readonly IProjectService _projectService;
    private readonly ICommand _getAllProjectsOfOneTeamCommand;
    private readonly ICommand _displaySprintsOfOneProjectCommand;
    private readonly ICommand _createTeamCommand;
    private readonly ICommand _deleteTeamCommand;
    private readonly ICommand _createProjectCommand;

    private int _currentTeamId;
    private TeamModel _currentTeam;
    private string _nameTeam;
    private string _nameProject;

    public ICommand GetAllProjectsOfOneTeamCommand
    {
        get => _getAllProjectsOfOneTeamCommand;
        private init => SetProperty(ref _getAllProjectsOfOneTeamCommand, value);
    }

    public ICommand DisplaySprintsOfOneProjectCommand
    {
        get => _displaySprintsOfOneProjectCommand;
        private init => SetProperty(ref _displaySprintsOfOneProjectCommand, value);
    }

    public ICommand CreateTeamCommand
    {
        get => _createTeamCommand;
        private init => SetProperty(ref _createTeamCommand, value);
    }
    
    public ICommand DeleteTeamCommand
    {
        get => _deleteTeamCommand;
        private init => SetProperty(ref _deleteTeamCommand, value);
    }
    
    public ICommand CreateProjectCommand
    {
        get => _createProjectCommand;
        private init => SetProperty(ref _createProjectCommand, value);
    }

    public string NameTeam
    {   
        get => _nameTeam;
        set => SetProperty(ref _nameTeam, value);
    }
    
    public string NameProject
    {   
        get => _nameProject;
        set => SetProperty(ref _nameProject, value);
    }

    public int CurrentTeamId
    {
        get => _currentTeamId;
        set => SetProperty(ref _currentTeamId, value);
    }

    public TeamModel CurrentTeam
    {
        get => _currentTeam;
        set => SetProperty(ref _currentTeam, value);
    }

    public ObservableCollection<TeamModel> Teams { get; } = new();

    public ObservableCollection<ProjectModel> Projects { get; } = new();



    public TeamViewModel(
        ITeamService teamService,
        IProjectService projectService)
    {
        _teamService = teamService;
        _projectService = projectService;

        GetAllTeamsOfOneUser(int.Parse(TokenService.GetClaimValue(ID_USER)));

        GetAllProjectsOfOneTeamCommand = new RelayCommand<int>(GetAllProjectsOfOneTeam);
        CreateTeamCommand = new RelayCommand(CreateTeam);
        DeleteTeamCommand = new RelayCommand<int>(DeleteTeam);
        CreateProjectCommand = new RelayCommand(CreateProject);
        DisplaySprintsOfOneProjectCommand = new RelayCommand<int>(SendDisplaySprintsOfOneProject);
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

        CurrentTeamId = id;
        CurrentTeam = await _teamService.Get(CurrentTeamId);
    }

    private async void CreateTeam()
    {
        var model = new TeamModel
        {
            NameTeam = NameTeam,
            NumberMembersTeam = 1
        };

        await _teamService.Create(model);

        Teams.Add(model);
        CurrentTeamId = model.IdTeam;
    }

    private async void DeleteTeam(int id)
    {
        await _teamService.DeleteTeam(id);

        Teams.Remove(Teams.SingleOrDefault(e => e.IdTeam == id)!);
    }

    private async void CreateProject()
    {
        var model = new ProjectModel
        {
            FkTeam = _currentTeamId,
            FkProjectType = 1,
            NameProject = NameProject
        };

        await _projectService.Create(model);

        Projects.Add(model);
    }

    private static void SendDisplaySprintsOfOneProject(int idProject)
        => WeakReferenceMessenger.Default.Send(new ShowSprintsButtonsMessage(idProject, true));
}
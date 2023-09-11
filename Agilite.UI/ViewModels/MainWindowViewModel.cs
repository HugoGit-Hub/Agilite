using Agilite.UI.Message;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly DefaultViewModel _defaultViewModel;
    private readonly TeamViewModel _teamViewModel;
    private readonly SprintViewModel _sprintViewModel;
    private readonly ISprintService _sprintService;
    private readonly ICommand _toggleSprintsButtons;

    private bool _showSprints;

    public static string DefaultView => nameof(Views.DefaultView);
    public static string TeamView => nameof(Views.TeamView);
    public static object SprintView => nameof(Views.SprintView);

    public ObservableObject ActualPage { get; private set; }
    public ObservableCollection<SprintModel> Sprints { get; } = new();
    public ICommand SwitchViewCommand { get; }
    public ICommand ToggleSprintsButtonsCommand
    {
        get => _toggleSprintsButtons;
        private init => SetProperty(ref _toggleSprintsButtons, value);
    }
    public ICommand SendSprintCommand { get; }
    public bool ShowSprints
    {
        get => _showSprints;
        set
        {
            if (_showSprints == value) return;
            _showSprints = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(
        DefaultViewModel defaultViewModel,
        TeamViewModel teamViewModel,
        SprintViewModel sprintViewModel,
        ISprintService sprintService)
    {
        SwitchViewCommand = new RelayCommand<string>(SwitchView);
        ToggleSprintsButtonsCommand = new RelayCommand(ToggleSprintsButtons);
        SendSprintCommand = new RelayCommand<int>(SendSprint);

        WeakReferenceMessenger.Default.Register<ShowSprintsButtonsMessage>(this, ShowSprintsButtonsAndDisplaySprints);

        ActualPage = defaultViewModel;

        _teamViewModel = teamViewModel;
        _defaultViewModel = defaultViewModel;
        _sprintViewModel = sprintViewModel;
        _sprintService = sprintService;
    }

    private void SwitchView(string? viewName)
    {
        if (viewName == null) throw new ArgumentNullException(nameof(viewName));

        ActualPage = viewName switch
        {
            nameof(Views.TeamView) => _teamViewModel,
            nameof(Views.SprintView) => _sprintViewModel,
            _ => _defaultViewModel
        };

        OnPropertyChanged(nameof(ActualPage));
    }
    
    private async void ShowSprintsButtonsAndDisplaySprints(object recipient, ShowSprintsButtonsMessage message)
    {
        var idProject = message.IdProject;
        if (idProject == 0) return;

        var sprints = await _sprintService.GetAllSprintsOfOneProject(idProject);
        Sprints.Clear();

        foreach (var sprint in sprints)
        {
            Sprints.Add(sprint);
        }

        ShowSprints = message.DisplaySprintsButtons;
    }

    private void ToggleSprintsButtons()
    {
        var _ = ShowSprints ? ShowSprints = false : ShowSprints = true;
    }

    private static void SendSprint(int sprintId)
    {
        var sprint = new SprintModel { IdSprint = sprintId };
        WeakReferenceMessenger.Default.Send(sprint);
    }
}
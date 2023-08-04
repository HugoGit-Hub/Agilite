using Agilite.UI.Message;
using Agilite.UI.Models.Models;
using Agilite.UI.Services.Services;
using Agilite.UI.Views;
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
    private readonly ISprintService _sprintService;
    private readonly ICommand _toggleSprintsButtons;

    private bool _showSprints;

    public static string DEFAULT_VIEW => nameof(DefaultView);
    public static string TEAM_VIEW => nameof(TeamView);

    public ObservableObject ActualPage { get; private set; }
    public ObservableCollection<SprintModel> Sprints { get; } = new();
    public ICommand ChangeViewCommand { get; }

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

    public ICommand ToggleSprintsButtonsCommand
    {
        get => _toggleSprintsButtons;
        private init => SetProperty(ref _toggleSprintsButtons, value);
    }

    public MainWindowViewModel(
        DefaultViewModel defaultViewModel,
        TeamViewModel teamViewModel,
        ISprintService sprintService)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);
        ToggleSprintsButtonsCommand = new RelayCommand(ToggleSprintsButtons);

        WeakReferenceMessenger.Default.Register<ShowSprintsButtonsMessage>(this, ShowSprintsButtonsAndDisplaySprints);

        ActualPage = defaultViewModel;

        _teamViewModel = teamViewModel;
        _sprintService = sprintService;
        _defaultViewModel = defaultViewModel;
    }

    private void SwitchView(string? viewName)
    {
        if (viewName == null) throw new ArgumentNullException(nameof(viewName));

        ActualPage = viewName switch
        {
            nameof(TeamView) => _teamViewModel,
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
}
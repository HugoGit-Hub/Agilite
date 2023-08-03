using Agilite.UI.Message;
using Agilite.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly DefaultViewModel _defaultViewModel;
    private readonly TeamViewModel _teamViewModel;
    private readonly ICommand _toggleSprintsButtons;

    private bool _showSprints;

    public static string DEFAULT_VIEW => nameof(DefaultView);
    public static string TEAM_VIEW => nameof(TeamView);

    public ObservableObject ActualPage { get; private set; }
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

    public MainWindowViewModel(DefaultViewModel defaultViewModel, TeamViewModel teamViewModel)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);
        ToggleSprintsButtonsCommand = new RelayCommand(ToggleSprintsButtons);

        WeakReferenceMessenger.Default.Register<ShowSprintsButtonsMessage>(this, ShowSprintsButtons);

        ActualPage = defaultViewModel;

        _teamViewModel = teamViewModel;
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

    private void ShowSprintsButtons(object recipient, ShowSprintsButtonsMessage message)
        => ShowSprints = message.Value;

    private void ToggleSprintsButtons()
    {
        var _ = ShowSprints ? ShowSprints = false : ShowSprints = true;
    }
}
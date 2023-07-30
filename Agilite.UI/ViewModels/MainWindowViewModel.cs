using Agilite.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    public static string DEFAULT_VIEW => nameof(DefaultView);

    public static string TEAM_VIEW => nameof(TeamView);

    private readonly DefaultViewModel _defaultViewModel;
    private readonly TeamViewModel _teamViewModel;

    public ObservableObject ActualPage { get; private set; }

    public ICommand ChangeViewCommand { get; }

    public MainWindowViewModel(
        DefaultViewModel defaultViewModel,
        TeamViewModel teamViewModel)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);

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
}
using Agilite.UI.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static string DEFAULT_VIEW => nameof(DefaultView);

    public static string TEAM_VIEW => nameof(TeamView);

    private readonly DefaultViewModel _defaultViewModel;
    private readonly TeamViewModel _teamViewModel;

    public ViewModelBase ActualPage { get; private set; }

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

    private void SwitchView(string viewName)
    {
        ActualPage = viewName switch
        {
            nameof(TeamView) => _teamViewModel,
            _ => _defaultViewModel
        };

        RaisePropertyChanged(nameof(ActualPage));
    }
}
using Agilite.UI.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public interface IMainWindowViewModel
{
    ICommand ChangeViewCommand { get; }
    object ActualPage { get; }
}

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    public static string DEFAULT_VIEW => nameof(DefaultView);

    private readonly IDefaultViewModel _defaultViewModel;

    public object ActualPage { get; private set; }

    public ICommand ChangeViewCommand { get; }

    public MainWindowViewModel(IDefaultViewModel defaultViewModel)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);

        ActualPage = defaultViewModel;

        _defaultViewModel = defaultViewModel;
    }

    private void SwitchView(string viewName)
    {
        ActualPage = viewName switch
        {
            _ => _defaultViewModel
        };

        NotifyPropertyChanged();
    }
}
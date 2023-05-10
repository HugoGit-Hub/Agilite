using Agilite.UI.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public interface IMainWindowViewModel
{
    ICommand ChangeViewCommand { get; }
    ViewModelBase? ActualPage { get; }
}

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    public static string CONTACT_VIEW => nameof(ContactView);
    public static string DEFAULT_VIEW => nameof(DefaultView);

    private readonly ContactViewModel _contactViewModel;
    private readonly DefaultViewModel _defaultView;

    public ViewModelBase ActualPage { get; private set; }

    public ICommand ChangeViewCommand { get; }

    public MainWindowViewModel(
        DefaultViewModel defaultView,
        ContactViewModel contactViewModel)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);

        ActualPage = defaultView;

        _defaultView = defaultView;
        _contactViewModel = contactViewModel;
    }

    private void SwitchView(string viewName)
    {
        ActualPage = viewName switch
        {
            nameof(ContactView) => _contactViewModel,
            _ => _defaultView
        };

        RaisePropertyChanged(nameof(ActualPage));
    }
}
using Agilite.UI.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace Agilite.UI.ViewModels;

public interface IMainWindowViewModel
{
    ICommand ChangeViewCommand { get; }
    ViewModelBase ActualPage { get; }
}

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    public static string DEFAULT_VIEW => nameof(DefaultView);
    public static string CONTACT_VIEW => nameof(ContactView);

    private readonly DefaultViewModel _defaultViewModel;
    private readonly ContactViewModel _contactViewModel;

    public ViewModelBase ActualPage { get; private set; }

    public ICommand ChangeViewCommand { get; }

    public MainWindowViewModel(
        DefaultViewModel defaultViewModel,
        ContactViewModel contactViewModel)
    {
        ChangeViewCommand = new RelayCommand<string>(SwitchView);

        ActualPage = defaultViewModel;

        _defaultViewModel = defaultViewModel;
        _contactViewModel = contactViewModel;
    }

    private void SwitchView(string viewName)
    {
        ActualPage = viewName switch
        {
            nameof(ContactView) => _contactViewModel,
            _ => _defaultViewModel
        };

        NotifyPropertyChanged();
    }
}
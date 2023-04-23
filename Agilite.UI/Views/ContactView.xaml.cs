using Agilite.UI.Data;
using Agilite.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Agilite.UI.Views;

public partial class ContactView : UserControl
{
    private readonly ContactsViewModel _viewModel;

    public ContactView()
    {
        InitializeComponent();
        _viewModel = new ContactsViewModel(new ContactDataProvider());
        DataContext = _viewModel;
        Loaded += ContactsView_Loaded;
    }

    private async void ContactsView_Loaded(object sender, RoutedEventArgs e)
    {
        await _viewModel.LoadAsync();
    }
}

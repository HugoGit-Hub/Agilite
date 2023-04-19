using Agilite.UI.Data;
using Agilite.UI.Services.Services;
using Agilite.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Agilite.UI.Controls;

public partial class DefaultPageControl : UserControl
{
    private readonly ContactsViewModel _viewModel;
    private readonly IContactService _contactService;

    public DefaultPageControl()
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

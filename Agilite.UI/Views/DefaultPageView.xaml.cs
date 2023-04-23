using Agilite.UI.ViewModels;
using System.Windows.Controls;

namespace Agilite.UI.Views;

public partial class DefaultPageView : UserControl
{
    private readonly ContactsViewModel _viewModel;

    public DefaultPageView()
    {
        InitializeComponent();
    }
}

using System.Windows.Controls;
using Agilite.UI.Data;
using Agilite.UI.ViewModels;

namespace Agilite.UI.Controls;

public partial class DefaultPageControl : UserControl
{
    public DefaultPageControl(IContactDataProvider contactDataProvider)
    {
        InitializeComponent();
        DataContext = new DefaultPageViewModel(contactDataProvider);
    }
}

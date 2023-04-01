using Agilite.UI.Data;
using Agilite.UI.ViewModels;

namespace Agilite.UI.Controls;

public partial class DefaultPageControl
{
    public DefaultPageControl()
    {
        InitializeComponent();
    }

    public DefaultPageControl(IContactDataProvider contactDataProvider)
    {
        InitializeComponent();
        DataContext = new DefaultPageViewModel(contactDataProvider);
    }
}

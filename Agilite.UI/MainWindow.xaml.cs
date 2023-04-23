using Agilite.UI.Views;
using System.Windows.Controls;

namespace Agilite.UI;

public partial class MainWindow
{
    ListViewItem? _ListViewItem;
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DefualtPageViewClick(object sender, System.Windows.RoutedEventArgs e)
    {
        DefaultView.Items.Clear();
        var defaultPageView = new DefaultPageView();
        _ListViewItem = new ListViewItem { Content = defaultPageView };
        DefaultView.Items.Add(_ListViewItem);
        DefaultView.Items.Refresh();
    }

    private void ContactViewClick(object sender, System.Windows.RoutedEventArgs e)
    {
        DefaultView.Items.Clear();
        var contactView = new ContactView();
        _ListViewItem = new ListViewItem { Content = contactView };
        DefaultView.Items.Add(_ListViewItem);
        DefaultView.Items.Refresh();
    }
}
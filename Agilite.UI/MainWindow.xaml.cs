using System.Windows;

namespace Agilite.UI;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }
}
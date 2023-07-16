using Agilite.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Agilite.UI.Views;

public partial class LoginView
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void WindowMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void ButtonMinimize(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void ButtonClose(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}

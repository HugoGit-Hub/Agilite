using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Agilite.UI.Resources.Logic;

public class CustomWindow : Window
{
    private Button? MinimizeButton { get; set; }
    private Grid? LayoutRoot { get; set; }
    private Button? MaximizeButton { get; set; }
    private Button? RestoreButton { get; set; }
    private Button? CloseButton { get; set; }

    public override void OnApplyTemplate()
    {
        GetRequiredTemplateChild<Grid>("WindowRoot");
        GetRequiredTemplateChild<Grid>("LayoutRoot");
        GetRequiredTemplateChild<Grid>("PART_HeaderBar");

        LayoutRoot = GetRequiredTemplateChild<Grid>("LayoutRoot");
        MinimizeButton = GetRequiredTemplateChild<Button>("MinimizeButton");
        MaximizeButton = GetRequiredTemplateChild<Button>("MaximizeButton");
        RestoreButton = GetRequiredTemplateChild<Button>("RestoreButton");
        CloseButton = GetRequiredTemplateChild<Button>("CloseButton");

        CloseButton.Click += CloseButton_Click;
        MinimizeButton.Click += MinimizeButton_Click;
        RestoreButton.Click += RestoreButton_Click;
        MaximizeButton.Click += MaximizeButton_Click;

        LayoutRoot?.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(WindowMouseDown));

        base.OnApplyTemplate();
    }

    private void WindowMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }

        
    }

    private T GetRequiredTemplateChild<T>(string? childName) where T : DependencyObject
    {
        return (T)GetTemplateChild(childName);
    }

    private void ToggleWindowState()
    {
        WindowState = WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
    }

    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        ToggleWindowState();
    }

    private void RestoreButton_Click(object sender, RoutedEventArgs e)
    {
        ToggleWindowState();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
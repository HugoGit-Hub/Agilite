using System;
using System.Windows.Input;

namespace Agilite.UI.ViewModels.Command;

public abstract class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter) => true;

    public abstract void Execute(object? parameter);

    protected void OnCanExecutedChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
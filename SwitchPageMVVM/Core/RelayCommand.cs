using System.Windows.Input;

namespace SwitchPageMVVM.Core;

public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter = null)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object? parameter = null)
    {
        execute(parameter);
    }
}
using System.Windows.Input;

namespace SmartRoute.util;

public class RelayCommand : ICommand
{
    //Occurs when changes take place that affect whether or not the command should execute.
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    private readonly Action<object?> _execute;
    private readonly Func<object?, bool> _canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    //Determines whether the command can execute in its current state.
    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    //Defines the method to be called when the command is invoked.
    public void Execute(object? parameter)
    {
        _execute(parameter);
    }
}
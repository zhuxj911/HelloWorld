using System.Windows.Input;

namespace SurApp.WpfLibrary;

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

    /// <summary>
    /// 默认能执行的命令，不需要传入canExecute
    /// </summary>
    /// <param name="execute"></param>
    public RelayCommand(Action<object?> execute) : this(execute, (paramters) => true)
    {
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
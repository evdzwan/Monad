using System.Windows.Input;

namespace Monad;

public sealed class Command : ICommand
{
    private readonly Predicate<object?> _canExecute;
    private readonly Func<object?, Task> _execute;

    private Command(Func<object?, Task> execute, Predicate<object?> canExecute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }

    public event EventHandler? CanExecuteChanged;

    [Description("Returns <code>true</code> while the command is executing.")]
    public bool IsExecuting { get; private set; }

    [Description("Invokes the provided can execute delegate.")]
    public bool CanExecute(object? parameter)
        => !IsExecuting && _canExecute(parameter);

    [Description("Creates a new command with sync execution, without parameters.")]
    public static Command Create(Action execute, Func<bool>? canExecute = null)
    {
        return new(_ =>
        {
            execute();
            return Task.CompletedTask;
        }, _ => canExecute?.Invoke() == true);
    }

    [Description("Creates a new command with sync execution, with a parameter.")]
    public static Command Create<T>(Action<T?> execute, Predicate<T?>? canExecute = null)
    {
        return new(param =>
        {
            execute(param is T typedParam ? typedParam : default);
            return Task.CompletedTask;
        }, param => canExecute?.Invoke(param is T typedParam ? typedParam : default) == true);
    }

    [Description("Creates a new command with async execution, without parameters.")]
    public static Command Create(Func<Task> execute, Func<bool>? canExecute = null)
        => new(_ => execute(), _ => canExecute?.Invoke() == true);

    [Description("Creates a new command with async execution, with a parameter.")]
    public static Command Create<T>(Func<T?, Task> execute, Predicate<T?>? canExecute = null)
        => new(param => execute(param is T typedParam ? typedParam : default), param => canExecute?.Invoke(param is T typedParam ? typedParam : default) == true);

    async void ICommand.Execute(object? parameter)
        => await Execute(parameter);

    [Description("Invokes the provided execute delegate.")]
    public async Task Execute(object? parameter)
    {
        if (!CanExecute(parameter))
        {
            throw new InvalidOperationException("Execution is not allowed");
        }

        IsExecuting = true;
        Invalidate();
        try
        {
            await _execute(parameter);
        }
        finally
        {
            IsExecuting = false;
            Invalidate();
        }
    }

    [Description("Notifies listeners that execution state has changed.")]
    public void Invalidate()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

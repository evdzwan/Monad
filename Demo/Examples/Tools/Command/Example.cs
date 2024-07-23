// create without parameters, with sync execution; second parameter is optional (defaults to true)
var command = Command.Create(() => ExecuteCommand(), () => CanExecuteCommand());

// create with parameters, with sync execution; second parameter is optional (defaults to true)
var command = Command.Create<int>(i => ExecuteCommand(i), i => CanExecuteCommand(i));

// create without parameters, with async execution; second parameter is optional (defaults to true)
var command = Command.Create<int>(() => ExecuteCommandAsync(), () => CanExecuteCommand());

// create with parameters, with async execution; second parameter is optional (defaults to true)
var command = Command.Create<int>(i => ExecuteCommandAsync(i), i => CanExecuteCommand(i));

// check for execution; execution is not allowed when already executing or can execute delegate returns false
if (command.CanExecute(42))
{
    // execute command
    await command.Execute(42);
}

// notify command listeners that can execute state changes
command.Invalidate();
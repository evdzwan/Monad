namespace Monad;

internal sealed class CommandTests
{
    [Test]
    public async Task TestCanExecute()
    {
        var tcs = new TaskCompletionSource();
        var command = Command.Create(() => tcs.Task, () => true);
        Assert.That(command.CanExecute(parameter: null), Is.True);

        var executionTask = command.Execute(parameter: null);
        Assert.That(command.CanExecute(parameter: null), Is.False);

        tcs.SetResult();
        await executionTask;
        Assert.That(command.CanExecute(parameter: null), Is.True);

        var canExecute = Substitute.For<Func<bool>>();
        canExecute.Invoke().Returns(true);
        command = Command.Create(Substitute.For<Action>(), canExecute);
        await command.Execute(parameter: null);
        canExecute.Received().Invoke();
    }

    [Test]
    public void TestCreate()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Command.Create(Substitute.For<Action>(), Substitute.For<Func<bool>>()), Is.InstanceOf<Command>());
            Assert.That(Command.Create(Substitute.For<Action<int>>(), Substitute.For<Predicate<int>>()), Is.InstanceOf<Command>());
            Assert.That(Command.Create(Substitute.For<Func<Task>>(), Substitute.For<Func<bool>>()), Is.InstanceOf<Command>());
            Assert.That(Command.Create(Substitute.For<Func<int, Task>>(), Substitute.For<Predicate<int>>()), Is.InstanceOf<Command>());
        });
    }

    [Test]
    public async Task TestExecute()
    {
        var action = Substitute.For<Action>();
        var command = Command.Create(action, () => true);
        await command.Execute(parameter: null);
        action.Received().Invoke();

        action.ClearReceivedCalls();
        command = Command.Create(action, () => false);
        Assert.ThrowsAsync<InvalidOperationException>(async () => await command.Execute(parameter: null));
        action.DidNotReceive().Invoke();
    }

    [Test]
    public void TestInvalidate()
    {
        var canExecuteChanged = Substitute.For<EventHandler>();
        var command = Command.Create(Substitute.For<Action>());
        command.CanExecuteChanged += canExecuteChanged;

        command.Invalidate();
        canExecuteChanged.Received().Invoke(command, Arg.Any<EventArgs>());
    }

    [Test]
    public async Task TestIsExecuting()
    {
        var tcs = new TaskCompletionSource();
        var command = Command.Create(() => tcs.Task, () => true);
        Assert.That(command.IsExecuting, Is.False);

        var executionTask = command.Execute(parameter: null);
        Assert.That(command.IsExecuting, Is.True);

        tcs.SetResult();
        await executionTask;
        Assert.That(command.IsExecuting, Is.False);
    }
}

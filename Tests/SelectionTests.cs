namespace Monad;

internal sealed class SelectionTests
{
    [Test]
    public void TestMultiple()
    {
        var singleSelection = new Selection<int>(Substitute.For<ICollection<int>>(), multiple: false);
        Assert.That(singleSelection.Multiple, Is.False);

        var multipleSelection = new Selection<int>(Substitute.For<ICollection<int>>(), multiple: true);
        Assert.That(multipleSelection.Multiple, Is.True);
    }

    [Test]
    public void TestTarget()
    {
        var target = Substitute.For<ICollection<int>>();
        var selection = new Selection<int>(target, multiple: false);
        Assert.That(selection.Target, Is.EqualTo(target));
    }

    [Test]
    public void TestActivate()
    {
        var target = Substitute.For<ICollection<int>>();
        var selection = new Selection<int>(target, multiple: false);

        target.Contains(42).Returns(false);
        selection.Activate(42);
        target.Received().Contains(42);
        target.Received().Add(42);

        target.ClearReceivedCalls();
        target.Contains(42).Returns(true);
        selection.Activate(42);
        target.Received().Contains(42);
        target.DidNotReceive().Add(42);
    }

    [Test]
    public void TestDeactivate()
    {
        var target = Substitute.For<ICollection<int>>();
        var selection = new Selection<int>(target, multiple: false);

        selection.Deactivate(42);
        target.Received().Remove(42);
    }

    [Test]
    public void TestIsActive()
    {
        var target = Substitute.For<ICollection<int>>();
        var selection = new Selection<int>(target, multiple: false);

        target.Contains(42).Returns(false);
        Assert.That(selection.IsActive(42), Is.False);
        target.Received().Contains(42);

        target.ClearReceivedCalls();
        target.Contains(42).Returns(true);
        Assert.That(selection.IsActive(42), Is.True);
        target.Received().Contains(42);
    }

    [Test]
    public void TestToggle()
    {
        var singleSelectionTarget = Substitute.For<ICollection<int>>();
        var singleSelection = new Selection<int>(singleSelectionTarget, multiple: false);
        singleSelectionTarget.Contains(37).Returns(false);
        singleSelectionTarget.Contains(42).Returns(true);

        singleSelection.Toggle(37);
        singleSelectionTarget.Received().Contains(37);
        singleSelectionTarget.Received().Clear();
        singleSelectionTarget.Received().Add(37);

        var multipleSelectionTarget = Substitute.For<ICollection<int>>();
        var multipleSelection = new Selection<int>(multipleSelectionTarget, multiple: true);
        multipleSelectionTarget.Contains(37).Returns(false);
        multipleSelectionTarget.Contains(42).Returns(true);

        multipleSelection.Toggle(37);
        multipleSelectionTarget.Received().Contains(37);
        multipleSelectionTarget.DidNotReceive().Clear();
        multipleSelectionTarget.Received().Add(37);
    }
}

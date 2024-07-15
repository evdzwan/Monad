namespace Monad;

internal sealed class DataGridItemsProviderResultTests
{
    [Test]
    public void TestItems()
    {
        var items = Substitute.For<IEnumerable<int>>();
        var result = new DataGridItemsProviderResult<int>(items, reachedEnd: false);
        Assert.That(result.Items, Is.EqualTo(items));
    }

    [Test]
    public void TestReachedEnd()
    {
        var boundResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), totalItemCount: 42);
        Assert.That(boundResult.ReachedEnd, Is.Null);

        var unboundCompleteResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), reachedEnd: true);
        Assert.That(unboundCompleteResult.ReachedEnd, Is.True);

        var unboundIncompleteResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), reachedEnd: false);
        Assert.That(unboundIncompleteResult.ReachedEnd, Is.False);
    }

    [Test]
    public void TestTotalItemCount()
    {
        var boundResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), totalItemCount: 42);
        Assert.That(boundResult.TotalItemCount, Is.EqualTo(42));

        var unboundCompleteResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), reachedEnd: true);
        Assert.That(unboundCompleteResult.TotalItemCount, Is.Null);

        var unboundIncompleteResult = new DataGridItemsProviderResult<int>(Substitute.For<IEnumerable<int>>(), reachedEnd: false);
        Assert.That(unboundIncompleteResult.TotalItemCount, Is.Null);
    }
}

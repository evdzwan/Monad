using Microsoft.Extensions.DependencyInjection;

namespace Monad.Components.Layouts;

internal sealed class GridCellTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var cell = RenderComponent<GridCell>(builder => builder.AddChildContent("fake-content"));
        Assert.That(cell.Instance.ChildContent, Is.Not.Null);
    }

    [Test]
    public void TestInitialize()
    {
        var grid = Substitute.For<Grid>();
        Services.AddCascadingValue(_ => grid);

        var cell = RenderComponent<GridCell>();
        grid.Received().AddCell(cell.Instance);
    }

    [Test]
    public void TestSpanX()
    {
        var cell = RenderComponent<GridCell>();
        Assert.That(cell.Instance.SpanX, Is.EqualTo(1));
    }

    [Test]
    public void TestSpanY()
    {
        var cell = RenderComponent<GridCell>();
        Assert.That(cell.Instance.SpanY, Is.EqualTo(1));
    }

    [Test]
    public void TestX()
    {
        var cell = RenderComponent<GridCell>();
        Assert.That(cell.Instance.X, Is.Zero);
    }

    [Test]
    public void TestY()
    {
        var cell = RenderComponent<GridCell>();
        Assert.That(cell.Instance.Y, Is.Zero);
    }
}

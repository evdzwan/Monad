using Microsoft.Extensions.DependencyInjection;

namespace Monad.Components.Layouts;

internal sealed class GridRowTests : BUnitTestContext
{
    [Test]
    public void TestHeight()
    {
        var row = RenderComponent<GridRow>();
        Assert.That(row.Instance.Height, Is.EqualTo(Size.Auto));
    }

    [Test]
    public void TestInitialize()
    {
        var grid = Substitute.For<Grid>();
        Services.AddCascadingValue(_ => grid);

        var row = RenderComponent<GridRow>();
        grid.Received().AddRow(row.Instance);
    }
}

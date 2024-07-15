using Microsoft.Extensions.DependencyInjection;

namespace Monad.Components.Layouts;

internal sealed class GridColumnTests : BUnitTestContext
{
    [Test]
    public void TestInitialize()
    {
        var grid = Substitute.For<Grid>();
        Services.AddCascadingValue(_ => grid);

        var column = RenderComponent<GridColumn>();
        grid.Received().AddColumn(column.Instance);
    }

    [Test]
    public void TestWidth()
    {
        var column = RenderComponent<GridColumn>();
        Assert.That(column.Instance.Width, Is.EqualTo(Size.Auto));
    }
}

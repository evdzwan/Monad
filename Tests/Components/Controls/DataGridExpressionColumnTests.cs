namespace Monad.Components.Controls;

internal sealed class DataGridExpressionColumnTests : BUnitTestContext
{
    [Test]
    public void TestPlaceholder()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>(builder => builder.Add(c => c.Placeholder, "fake-placeholder"));
        Assert.That(column.Instance.Placeholder, Is.Not.Null);
    }

    [Test]
    public void TestTitle()
    {
        var columnWithoutExplicitTitle = RenderComponent<DataGridExpressionColumn<Context, int>>(builder => builder.Add(c => c.Value, ctx => ctx.Value));
        var headerWithoutExplicitTitle = Render(columnWithoutExplicitTitle.Instance.HeaderContent);
        headerWithoutExplicitTitle.MarkupMatches(nameof(Context.Value));

        var columnWithExplicitTitle = RenderComponent<DataGridExpressionColumn<Context, int>>(builder => builder.Add(c => c.Title, "fake-title"));
        var headerWithExplicitTitle = Render(columnWithExplicitTitle.Instance.HeaderContent);
        headerWithExplicitTitle.MarkupMatches("fake-title");
    }

    [Test]
    public void TestValue()
    {
        var column = RenderComponent<DataGridExpressionColumn<Context, int>>(builder => builder.Add(c => c.Value, ctx => ctx.Value));
        Assert.That(column.Instance.CellContent, Is.Not.Null);
    }

    [Test]
    public void TestWidth()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>();
        Assert.That(column.Instance.Width.Unit, Is.EqualTo(SizeUnit.Auto));
    }

    private sealed class Context
    {
        public int Value { get; set; }
    }
}

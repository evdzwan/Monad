namespace Monad.Components.Controls;

internal sealed class DataGridTemplateColumnTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>(builder => builder.Add(c => c.ChildContent, _ => "fake-content"));
        var cell = Render(column.Instance.CellContent(42));
        cell.MarkupMatches("fake-content");
    }

    [Test]
    public void TestPlaceholder()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>(builder => builder.Add(c => c.Placeholder, "fake-placeholder"));
        Assert.That(column.Instance.Placeholder, Is.Not.Null);
    }

    [Test]
    public void TestTitle()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>(builder => builder.Add(c => c.Title, "fake-title"));
        var header = Render(column.Instance.HeaderContent);
        header.MarkupMatches("fake-title");
    }

    [Test]
    public void TestWidth()
    {
        var column = RenderComponent<DataGridTemplateColumn<int>>();
        Assert.That(column.Instance.Width.Unit, Is.EqualTo(SizeUnit.Auto));
    }
}

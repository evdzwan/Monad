namespace Monad.Components.Layouts;

internal sealed class StackTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var stack = RenderComponent<Stack>(builder => builder.AddChildContent("fake-content"));
        stack.MarkupMatches("""<div class="stack">fake-content</div>""");
    }

    [Test]
    public void TestHorizontal()
    {
        var stack = RenderComponent<Stack>(builder => builder.Add(c => c.Horizontal, true));
        stack.MarkupMatches("""<div class="stack horizontal" />""");
    }

    [Test]
    public void TestVertical()
    {
        var stack = RenderComponent<Stack>(builder => builder.Add(c => c.Vertical, true));
        stack.MarkupMatches("""<div class="stack vertical" />""");
    }
}

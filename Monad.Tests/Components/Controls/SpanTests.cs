namespace Monad.Components.Controls;

internal sealed class SpanTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var span = RenderComponent<Span>(builder => builder.AddChildContent("fake-content"));
        span.MarkupMatches("""<div class="span" style="">fake-content</div>""");
    }

    [Test]
    public void TestHorizontal()
    {
        var span = RenderComponent<Span>(builder => builder.AddChildContent("fake-content")
                                                           .Add(c => c.Horizontal, 2));

        span.MarkupMatches("""<div class="span" style="grid-column: span 2">fake-content</div>""");
    }

    [Test]
    public void TestVertical()
    {
        var span = RenderComponent<Span>(builder => builder.AddChildContent("fake-content")
                                                           .Add(c => c.Vertical, 2));

        span.MarkupMatches("""<div class="span" style="grid-row: span 2">fake-content</div>""");
    }
}

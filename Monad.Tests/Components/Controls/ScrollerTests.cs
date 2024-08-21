namespace Monad.Components.Controls;

internal sealed class ScrollerTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var scroller = RenderComponent<Scroller>(builder => builder.AddChildContent("fake-content"));
        scroller.MarkupMatches("""<div class="scroller">fake-content</div>""");
    }

    [Test]
    public void TestHorizontal()
    {
        var scroller = RenderComponent<Scroller>(builder => builder.AddChildContent("fake-content").Add(c => c.Horizontal, true));
        scroller.MarkupMatches("""<div class="scroller horizontal">fake-content</div>""");
    }

    [Test]
    public void TestVertical()
    {
        var scroller = RenderComponent<Scroller>(builder => builder.AddChildContent("fake-content").Add(c => c.Vertical, true));
        scroller.MarkupMatches("""<div class="scroller vertical">fake-content</div>""");
    }
}

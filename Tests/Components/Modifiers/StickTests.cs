namespace Monad.Components.Modifiers;

internal sealed class StickTests : BUnitTestContext
{
    [Test]
    public void TestBottom()
    {
        var stick = RenderComponent<Stick>(builder => builder.AddChildContent("fake-content").Add(c => c.Bottom, true));
        stick.MarkupMatches("""<div class="stick bottom">fake-content</div>""");
    }

    [Test]
    public void TestChildContent()
    {
        var stick = RenderComponent<Stick>(builder => builder.AddChildContent("fake-content"));
        stick.MarkupMatches("""<div class="stick">fake-content</div>""");
    }

    [Test]
    public void TestTop()
    {
        var stick = RenderComponent<Stick>(builder => builder.AddChildContent("fake-content").Add(c => c.Top, true));
        stick.MarkupMatches("""<div class="stick top">fake-content</div>""");
    }
}

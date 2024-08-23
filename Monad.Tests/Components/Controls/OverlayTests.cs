namespace Monad.Components.Controls;

internal sealed class OverlayTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var overlay = RenderComponent<Overlay>(builder => builder.AddChildContent("fake-content"));
        overlay.MarkupMatches("""<div class="overlay">fake-content</div>""");
    }
}

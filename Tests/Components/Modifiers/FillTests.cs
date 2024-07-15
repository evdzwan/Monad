namespace Monad.Components.Modifiers;

internal sealed class FillTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var fill = RenderComponent<Fill>(builder => builder.AddChildContent("fake-content"));
        fill.MarkupMatches("""<div class="fill">fake-content</div>""");
    }
}

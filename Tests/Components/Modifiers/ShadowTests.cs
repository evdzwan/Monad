namespace Monad.Components.Modifiers;

internal sealed class ShadowTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var shadow = RenderComponent<Shadow>(builder => builder.AddChildContent("fake-content"));
        shadow.MarkupMatches("""<div class="shadow">fake-content</div>""");
    }

    [Test]
    public void TestSmall()
    {
        var shadow = RenderComponent<Shadow>(builder => builder.AddChildContent("fake-content").Add(c => c.Small, true));
        shadow.MarkupMatches("""<div class="shadow small">fake-content</div>""");
    }
}

namespace Monad.Components.Controls;

internal sealed class ShadowTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var shadow = RenderComponent<Shadow>(builder => builder.AddChildContent("fake-content"));
        shadow.MarkupMatches("""<div class="shadow">fake-content</div>""");
    }
}

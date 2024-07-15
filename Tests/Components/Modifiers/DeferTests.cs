namespace Monad.Components.Modifiers;

internal sealed class DeferTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var defer = RenderComponent<Defer>(builder => builder.AddChildContent("fake-content"));
        defer.MarkupMatches("fake-content");
    }
}

namespace Monad.Components.Controls;

internal sealed class CollapserTests : BUnitTestContext
{
    [Test]
    public void TestActive()
    {
        var nonActiveCollapse = RenderComponent<Collapser>(builder => builder.Add(c => c.Active, false));
        nonActiveCollapse.MarkupMatches("""
            <div class="collapser">
                <div class="collapser-container">
                    <div class="collapser-content" />
                </div>
            </div>
            """);

        var activeCollapse = RenderComponent<Collapser>(builder => builder.Add(c => c.Active, true));
        activeCollapse.MarkupMatches("""
            <div class="collapser active">
                <div class="collapser-container">
                    <div class="collapser-content" />
                </div>
            </div>
            """);
    }

    [Test]
    public void TestChildContent()
    {
        var collapse = RenderComponent<Collapser>(builder => builder.AddChildContent("fake-content"));
        collapse.MarkupMatches("""
            <div class="collapser">
                <div class="collapser-container">
                    <div class="collapser-content">
                        fake-content
                    </div>
                </div>
            </div>
            """);
    }
}

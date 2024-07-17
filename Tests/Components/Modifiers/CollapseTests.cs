namespace Monad.Components.Modifiers;

internal sealed class CollapseTests : BUnitTestContext
{
    [Test]
    public void TestActive()
    {
        var nonActiveCollapse = RenderComponent<Collapse>(builder => builder.Add(c => c.Active, false));
        nonActiveCollapse.MarkupMatches("""
            <div class="collapse">
                <div class="collapse-outer">
                    <div class="collapse-inner" />
                </div>
            </div>
            """);

        var activeCollapse = RenderComponent<Collapse>(builder => builder.Add(c => c.Active, true));
        activeCollapse.MarkupMatches("""
            <div class="collapse active">
                <div class="collapse-outer">
                    <div class="collapse-inner" />
                </div>
            </div>
            """);
    }

    [Test]
    public void TestChildContent()
    {
        var collapse = RenderComponent<Collapse>(builder => builder.AddChildContent("fake-content"));
        collapse.MarkupMatches("""
            <div class="collapse">
                <div class="collapse-outer">
                    <div class="collapse-inner">
                        fake-content
                    </div>
                </div>
            </div>
            """);
    }
}

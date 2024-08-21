namespace Monad.Components.Controls;

internal sealed class ResponderTests : BUnitTestContext
{
    [Test]
    public void TestDefault()
    {
        var responder = RenderComponent<Responder>(builder => builder.Add(c => c.Default, "fake-content"));
        responder.MarkupMatches("""
            <div class="responder">
                <div class="responder-content">fake-content</div>
                <div class="responder-content-sm"></div>
                <div class="responder-content-md"></div>
                <div class="responder-content-lg"></div>
            </div>
            """);
    }

    [Test]
    public void TestLarge()
    {
        var responder = RenderComponent<Responder>(builder => builder.Add(c => c.Large, "fake-content"));
        responder.MarkupMatches("""
            <div class="responder">
                <div class="responder-content"></div>
                <div class="responder-content-sm"></div>
                <div class="responder-content-md"></div>
                <div class="responder-content-lg">fake-content</div>
            </div>
            """);
    }

    [Test]
    public void TestMedium()
    {
        var responder = RenderComponent<Responder>(builder => builder.Add(c => c.Medium, "fake-content"));
        responder.MarkupMatches("""
            <div class="responder">
                <div class="responder-content"></div>
                <div class="responder-content-sm"></div>
                <div class="responder-content-md">fake-content</div>
                <div class="responder-content-lg"></div>
            </div>
            """);
    }

    [Test]
    public void TestSmall()
    {
        var responder = RenderComponent<Responder>(builder => builder.Add(c => c.Small, "fake-content"));
        responder.MarkupMatches("""
            <div class="responder">
                <div class="responder-content"></div>
                <div class="responder-content-sm">fake-content</div>
                <div class="responder-content-md"></div>
                <div class="responder-content-lg"></div>
            </div>
            """);
    }
}

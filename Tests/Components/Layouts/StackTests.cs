namespace Monad.Components.Layouts;

internal sealed class StackTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var stack = RenderComponent<Stack>(builder => builder.AddChildContent("fake-content"));
        stack.MarkupMatches("""<div class="stack vertical">fake-content</div>""");
    }

    [Test]
    public void TestOrientation()
    {
        var horizontalStack = RenderComponent<Stack>(builder => builder.Add(c => c.Orientation, Orientation.Horizontal));
        horizontalStack.MarkupMatches("""<div class="stack horizontal" />""");

        var verticalStack = RenderComponent<Stack>(builder => builder.Add(c => c.Orientation, Orientation.Vertical));
        verticalStack.MarkupMatches("""<div class="stack vertical" />""");
    }
}

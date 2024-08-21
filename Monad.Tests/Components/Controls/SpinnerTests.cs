namespace Monad.Components.Controls;

internal sealed class SpinnerTests : BUnitTestContext
{
    [Test]
    public void TestRender()
    {
        var spinner = RenderComponent<Spinner>();
        spinner.MarkupMatches("""<div class="spinner" />""");
    }
}

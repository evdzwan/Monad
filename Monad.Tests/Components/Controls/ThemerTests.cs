using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

internal sealed class ThemerTests : BUnitTestContext
{
    [Test]
    public void TestChildContent()
    {
        var themer = RenderComponent<Themer>(builder => builder.AddChildContent("fake-content"));
        themer.MarkupMatches("""<div class="themer" monad-theme="dark">fake-content</div>""");
    }

    [Test]
    public void TestTheme()
    {
        var themer = RenderComponent<Themer>(builder => builder.AddChildContent(builder =>
        {
            builder.OpenComponent<ChildComponent>(sequence: 0);
            builder.CloseComponent();
        }).Add(c => c.Theme, "fake-theme"));

        Assert.That(themer.FindComponent<ChildComponent>().Instance.ThemeController, Is.Not.Null);
        Assert.That(themer.FindComponent<ChildComponent>().Instance.ThemeController.Theme, Is.EqualTo("fake-theme"));
    }

    private sealed class ChildComponent : ComponentBase
    {
        [CascadingParameter]
        internal IThemeController? ThemeController { get; set; }
    }
}

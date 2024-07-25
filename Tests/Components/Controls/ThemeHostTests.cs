using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

internal sealed class ThemeHostTests : BUnitTestContext
{
    public ThemeHostTests()
    {
        JSInterop.SetupVoid("localStorage.setItem", "monad-theme", "fake-theme");
        JSInterop.Setup<string?>("localStorage.getItem", "monad-theme").SetResult(null);
    }

    [Test]
    public void TestChildContent()
    {
        var themeHost = RenderComponent<ThemeHost>(builder => builder.AddChildContent("fake-content"));
        themeHost.MarkupMatches("""<div class="theme-host">fake-content</div>""");
    }

    [Test]
    public void TestDefaultTheme()
    {
        var themeHost = RenderComponent<ThemeHost>(builder => builder.AddChildContent(builder =>
        {
            builder.OpenComponent<ChildComponent>(sequence: 0);
            builder.CloseComponent();
        }).Add(c => c.DefaultTheme, "fake-theme"));
        Assert.That(themeHost.FindComponent<ChildComponent>().Instance.ThemeController?.CurrentTheme, Is.EqualTo("fake-theme"));
        
        JSInterop.Setup<string?>("localStorage.getItem", "monad-theme").SetResult("other-theme");
        themeHost = RenderComponent<ThemeHost>(builder => builder.AddChildContent(builder =>
        {
            builder.OpenComponent<ChildComponent>(sequence: 0);
            builder.CloseComponent();
        }).Add(c => c.DefaultTheme, "fake-theme"));
        Assert.That(themeHost.FindComponent<ChildComponent>().Instance.ThemeController?.CurrentTheme, Is.EqualTo("other-theme"));
    }

    [Test]
    public void TestFixedTheme()
    {
        var themeHost = RenderComponent<ThemeHost>(builder => builder.AddChildContent(builder =>
        {
            builder.OpenComponent<ChildComponent>(sequence: 0);
            builder.CloseComponent();
        }).Add(c => c.FixedTheme, "fake-theme"));

        Assert.That(themeHost.FindComponent<ChildComponent>().Instance.ThemeController, Is.Not.Null);
        Assert.That(themeHost.FindComponent<ChildComponent>().Instance.ThemeController.CurrentTheme, Is.EqualTo("fake-theme"));
    }

    private sealed class ChildComponent : ComponentBase
    {
        [CascadingParameter]
        internal IThemeController? ThemeController { get; set; }
    }
}

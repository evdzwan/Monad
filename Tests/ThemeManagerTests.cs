using Microsoft.JSInterop;

namespace Monad;

internal sealed class ThemeManagerTests
{
    [Test]
    public async Task TestCurrentThemeChanged()
    {
        var currentThemeChanged = Substitute.For<Action<string?>>();
        var themeManager = new ThemeManager(defaultTheme: null, jsRuntime: null);
        themeManager.CurrentThemeChanged += currentThemeChanged;

        await themeManager.SetCurrentTheme("fake-theme");
        currentThemeChanged.Received().Invoke("fake-theme");
    }

    [Test]
    public async Task TestGetCurrentTheme()
    {
        var jsRuntime = Substitute.For<IJSRuntime>();
        var themeManager = new ThemeManager("fake-default-theme", jsRuntime);
        Assert.That(await themeManager.GetCurrentTheme(), Is.EqualTo("fake-default-theme"));

        jsRuntime.InvokeAsync<string>("localStorage.getItem", Arg.Any<object?[]>()).Returns("fake-js-theme");
        Assert.That(await themeManager.GetCurrentTheme(), Is.EqualTo("fake-js-theme"));
    }

    [Test]
    public async Task TestSetCurrentTheme()
    {
        var jsRuntime = Substitute.For<IJSRuntime>();
        var themeManager = new ThemeManager("fake-default-theme", jsRuntime);

        await themeManager.SetCurrentTheme("fake-theme");
        await jsRuntime.Received().InvokeVoidAsync("localStorage.setItem", Arg.Any<object?[]>());
    }
}

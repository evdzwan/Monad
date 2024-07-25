namespace Monad;

internal sealed class ThemeControllerTests
{
    [Test]
    public void TestCurrentTheme()
    {
        var themeController = new ThemeController();
        Assert.That(themeController.CurrentTheme, Is.Null);

        var currentThemeChanged = Substitute.For<Action<string?>>();
        themeController.CurrentThemeChanged += currentThemeChanged;

        themeController.CurrentTheme = "fake-theme";
        currentThemeChanged.Received().Invoke("fake-theme");
    }
}

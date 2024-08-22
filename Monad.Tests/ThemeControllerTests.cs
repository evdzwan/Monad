namespace Monad;

internal sealed class ThemeControllerTests
{
    [Test]
    public void TestThemeChanged()
    {
        var themeController = new ThemeController();

        var themeChanged = Substitute.For<Action<string?>>();
        themeController.ThemeChanged += themeChanged;

        themeController.SetTheme("fake-theme");
        themeChanged.Received().Invoke("fake-theme");
    }

    [Test]
    public void TestSetTheme()
    {
        var themeController = new ThemeController();
        Assert.That(themeController.Theme, Is.Null);

        themeController.SetTheme("fake-theme");
        Assert.That(themeController.Theme, Is.EqualTo("fake-theme"));
    }

    [Test]
    public void TestTheme()
    {
        var themeController = new ThemeController("fake-theme");
        Assert.That(themeController.Theme, Is.EqualTo("fake-theme"));
    }
}

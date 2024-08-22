namespace Monad;

internal sealed class ThemeController(string? theme = null) : IThemeController
{
    public event Action<string?>? ThemeChanged;

    public string? Theme
    {
        get => theme;
        private set => Value.Exchange(ref theme, value, theme => ThemeChanged?.Invoke(theme));
    }

    public void SetTheme(string? theme)
        => Theme = theme;
}

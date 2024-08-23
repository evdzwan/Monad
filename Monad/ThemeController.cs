namespace Monad;

internal sealed class ThemeController(string? theme = null) : IThemeController
{
    public event Action<string?>? ThemeChanged;

    public string? Theme
    {
        get => theme;
        internal set => Value.Exchange(ref theme, value);
    }

    public void SetTheme(string? theme)
    {
        Theme = theme;
        ThemeChanged?.Invoke(theme);
    }
}

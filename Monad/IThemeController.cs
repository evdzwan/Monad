namespace Monad;

public interface IThemeController
{
    internal event Action<string?>? ThemeChanged;

    [Description("Current theme.")]
    string? Theme { get; }

    [Description("Sets the current theme.")]
    void SetTheme(string? theme);
}

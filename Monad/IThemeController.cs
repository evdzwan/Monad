namespace Monad;

public interface IThemeController
{
    internal event Action<string?>? ThemeChanged;

    string? Theme { get; }

    void SetTheme(string? theme);
}

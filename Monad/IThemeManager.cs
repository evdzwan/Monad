namespace Monad;

public interface IThemeManager
{
    event Action<string?>? CurrentThemeChanged;

    ValueTask<string?> GetCurrentTheme();

    ValueTask SetCurrentTheme(string? theme);
}

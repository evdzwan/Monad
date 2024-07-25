namespace Monad;

internal sealed class ThemeController() : IThemeController
{
    private string? _currentTheme;
    
    public string? CurrentTheme
    {
        get => _currentTheme;
        set => Value.Exchange(ref _currentTheme, value, theme => CurrentThemeChanged?.Invoke(theme));
    }

    public event Action<string?>? CurrentThemeChanged;
}

using Microsoft.JSInterop;

namespace Monad;

internal sealed class ThemeManager(string? defaultTheme, IJSRuntime? jsRuntime) : IThemeManager
{
    private const string ThemeKey = "monad-theme";

    public event Action<string?>? CurrentThemeChanged;

    private string? CachedTheme { get; set; }

    public async ValueTask<string?> GetCurrentTheme()
    {
        if (CachedTheme is null && jsRuntime is { } js)
        {
            var theme = await js.InvokeAsync<string>("localStorage.getItem", ThemeKey);
            if (theme is { Length: > 0 })
            {
                CachedTheme = theme;
            }
        }

        return CachedTheme ?? defaultTheme;
    }

    public async ValueTask SetCurrentTheme(string? theme)
    {
        if (theme != CachedTheme)
        {
            CachedTheme = theme;
            CurrentThemeChanged?.Invoke(theme);
            if (jsRuntime is { } js)
            {
                await js.InvokeVoidAsync("localStorage.setItem", ThemeKey, theme);
            }
        }
    }
}

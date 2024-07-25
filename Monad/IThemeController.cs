namespace Monad;

public interface IThemeController
{
    internal event Action<string?>? CurrentThemeChanged;

    [Description("Gets or sets the current CSS theme.")]
    string? CurrentTheme { get; set; }
}

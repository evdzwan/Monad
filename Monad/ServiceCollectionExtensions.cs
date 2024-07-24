using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace Monad;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBinder(this IServiceCollection @this, Action<IBinderConfiguration>? configure = null)
    {
        var configuration = new BinderConfiguration(@this);
        configure?.Invoke(configuration);

        return @this.AddSingleton<IBinderConfiguration>(configuration)
                    .AddScoped<IBinder, Binder>();
    }

    public static IServiceCollection AddThemes(this IServiceCollection @this, string? defaultTheme = null)
        => @this.AddScoped<IThemeManager>(sp => new ThemeManager(defaultTheme, sp.GetService<IJSRuntime>()));
}

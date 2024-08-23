using Microsoft.Extensions.DependencyInjection;

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
}

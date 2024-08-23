using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Monad;

internal sealed class BinderConfiguration(IServiceCollection services) : IBinderConfiguration
{
    public IBinderConfiguration AddBinding<TComponent, TValue, TBinding>() where TComponent : IComponent where TBinding : Binding<TComponent, TValue>
    {
        services.AddScoped<Binding<TComponent, TValue>, TBinding>();
        return this;
    }
}

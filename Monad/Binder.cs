using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Monad;

internal sealed class Binder(IServiceProvider serviceProvider) : IBinder
{
    public Task Bind<TComponent, TValue>(TComponent component, Expression<Func<TValue>> expression) where TComponent : IComponent
    {
        var binding = serviceProvider.GetRequiredService<Binding<TComponent, TValue>>();
        return binding.Apply(component, expression);
    }
}

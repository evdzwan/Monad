using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Monad;

public interface IBinder
{
    [Description("Bind the provided expression to the component.")]
    Task Bind<TComponent, TValue>(TComponent component, Expression<Func<TValue>> expression) where TComponent : IComponent;
}

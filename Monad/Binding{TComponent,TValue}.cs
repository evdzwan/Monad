using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Monad;

public abstract class Binding<TComponent, TValue> where TComponent : IComponent
{
    internal Task Apply(TComponent component, Expression<Func<TValue>> expression)
    {
        var bindable = new Bindable<TComponent>();
        Apply(bindable, expression);
        return bindable.Apply(component);
    }

    protected abstract void Apply(Bindable<TComponent> bindable, Expression<Func<TValue>> expression);
}

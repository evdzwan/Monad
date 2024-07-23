using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Monad;

public sealed class Bindable<TComponent> where TComponent : IComponent
{
    private ConcurrentDictionary<string, object?> Values { get; } = [];

    internal Task Apply(TComponent component)
        => Values.IsEmpty ? Task.CompletedTask : component.SetParametersAsync(ParameterView.FromDictionary(Values));

    public void Set(Expression<Func<TComponent, RenderFragment?>> selector, string? markup)
        => Set(selector, new RenderFragment(builder => builder.AddMarkupContent(sequence: 0, markup)));

    public void Set<TValue>(Expression<Func<TComponent, TValue>> selector, TValue value)
    {
        var property = selector.GetPropertyInfo();
        if (property.GetCustomAttribute<ParameterAttribute>() is null)
        {
            throw new ArgumentException($"Property '{property.Name}' must be a parameter", nameof(selector));
        }

        Values.TryAdd(property.Name, value);
    }
}

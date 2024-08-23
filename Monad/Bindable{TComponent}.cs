using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Monad;

public sealed class Bindable<TComponent> where TComponent : IComponent
{
    private readonly ConcurrentDictionary<string, object?> _values = [];

    public Bindable()
        => Values = new ReadOnlyDictionary<string, object?>(_values);

    internal IReadOnlyDictionary<string, object?> Values { get; }

    internal Task Apply(TComponent component)
        => _values.IsEmpty ? Task.CompletedTask : component.SetParametersAsync(ParameterView.FromDictionary(_values));

    public void Set(Expression<Func<TComponent, RenderFragment?>> selector, string? markup)
        => Set(selector, new RenderFragment(builder => builder.AddMarkupContent(sequence: 0, markup)));

    public void Set<TValue>(Expression<Func<TComponent, TValue>> selector, TValue value)
    {
        var property = selector.GetPropertyInfo();
        if (property.GetCustomAttribute<ParameterAttribute>() is null)
        {
            throw new ArgumentException($"Property '{property.Name}' must be a parameter", nameof(selector));
        }

        _values.TryAdd(property.Name, value);
    }
}

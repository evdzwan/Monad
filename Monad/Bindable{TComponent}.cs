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

    [Description("Sets a component parameter of type <code>RenderFragment</code> using the <code>selector</code> argument.")]
    public void Set(Expression<Func<TComponent, RenderFragment?>> selector, string? markup)
        => Set(selector, new RenderFragment(builder => builder.AddMarkupContent(sequence: 0, markup)));

    [Description("Sets a component parameter using the <code>selector</code> argument.")]
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

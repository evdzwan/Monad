using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components.Rendering;
using System.Linq.Expressions;

namespace Monad.Components.Controls;

public abstract class DataGridColumn<TItem> : ComponentBase
{
    [CascadingParameter]
    private DataGrid<TItem>? DataGrid { get; set; }

    [Parameter]
    public string? Title { get; set; }

    protected override void OnInitialized()
        => DataGrid?.Columns.Add(this);

    protected internal abstract void Render(RenderTreeBuilder builder);
}

public sealed class DataGridColumn<TItem, TValue> : DataGridColumn<TItem>
{
    [Parameter, EditorRequired]
    public required Expression<Func<TItem, TValue>> Value { get; set; }

    protected internal override void Render(RenderTreeBuilder builder)
    {
        builder.OpenComponent<PropertyColumn<TItem, TValue>>(sequence: 0);
        builder.AddComponentParameter(sequence: 1, nameof(PropertyColumn<TItem, TValue>.Property), Value);
        builder.AddComponentParameter(sequence: 2, nameof(PropertyColumn<TItem, TValue>.Title), Title);
        builder.CloseComponent();
    }
}

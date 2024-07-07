using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridRow : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter]
    public GridDimension Height { get; set; } = GridDimension.Auto;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Rows.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Rows.Add(this);
}

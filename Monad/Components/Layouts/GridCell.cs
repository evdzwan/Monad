using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridCell : ComponentBase, IDisposable
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter]
    public int SpanX { get; set; } = 1;

    [Parameter]
    public int SpanY { get; set; } = 1;

    [Parameter]
    public int X { get; set; }

    [Parameter]
    public int Y { get; set; }

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Cells.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Cells.Add(this);
}

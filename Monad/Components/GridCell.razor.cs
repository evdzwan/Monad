using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class GridCell
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    private Grid Grid { get; set; } = default!;

    [Parameter]
    public int SpanX { get; set; } = 1;

    [Parameter]
    public int SpanY { get; set; } = 1;

    [Parameter, EditorRequired]
    public required int X { get; set; }

    [Parameter, EditorRequired]
    public required int Y { get; set; }

    protected override void OnInitialized()
        => Grid.Cells.Add(this);
}

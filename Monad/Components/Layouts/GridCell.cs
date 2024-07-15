using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Layouts;

public sealed class GridCell : ComponentBase
{
    [Parameter, Description("Content to be rendered.")]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Column span. Defaults to <code>1</code>.")]
    public int SpanX { get; set; } = 1;

    [Parameter, Description("Row span. Defaults to <code>1</code>.")]
    public int SpanY { get; set; } = 1;

    [Parameter, Description("Column index, 0-based.")]
    public int X { get; set; }

    [Parameter, Description("Row index, 0-based.")]
    public int Y { get; set; }

    protected override void OnInitialized()
        => Grid?.AddCell(this);
}

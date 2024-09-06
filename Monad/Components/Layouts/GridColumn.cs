using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridColumn : ComponentBase
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Determines at which screen size the column is visible.")]
    public Breakpoint? Scope { get; set; }

    [Parameter, Description("Column width. Defaults to <code>GridSize.Auto</code>.")]
    public Size Width { get; set; } = Size.Auto;

    protected override void OnInitialized()
        => Grid?.AddColumn(this);
}

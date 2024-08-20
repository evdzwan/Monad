using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridColumn : ComponentBase
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter]
    public Breakpoint? Scope { get; set; }

    [Parameter]
    public Size Width { get; set; } = Size.Auto;

    protected override void OnInitialized()
        => Grid?.AddColumn(this);
}

using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Layouts;

public sealed class GridColumn : ComponentBase
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Column width. Defaults to <code>Size.Auto</code>.")]
    public Size Width { get; set; } = Size.Auto;

    protected override void OnInitialized()
        => Grid?.AddColumn(this);
}

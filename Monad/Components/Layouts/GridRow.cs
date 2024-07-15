using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Layouts;

public sealed class GridRow : ComponentBase
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Row height. Defaults to <code>Size.Auto</code>.")]
    public Size Height { get; set; } = Size.Auto;

    protected override void OnInitialized()
        => Grid?.AddRow(this);
}

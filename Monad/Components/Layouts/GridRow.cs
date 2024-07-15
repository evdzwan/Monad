using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Layouts;

public sealed class GridRow : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Row height. Defaults to <code>Size.Auto</code>.")]
    public Size Height { get; set; } = Size.Auto;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Rows.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Rows.Add(this);
}

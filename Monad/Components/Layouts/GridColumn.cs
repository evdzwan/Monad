using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Layouts;

public sealed class GridColumn : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter, Description("Column width. Defaults to <code>Size.Auto</code>.")]
    public Size Width { get; set; } = Size.Auto;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Columns.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Columns.Add(this);
}

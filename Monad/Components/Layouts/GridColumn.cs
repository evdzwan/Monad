using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridColumn : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter]
    public Size Width { get; set; } = Size.Auto;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Columns.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Columns.Add(this);
}

using Microsoft.AspNetCore.Components;

namespace Monad.Components.Layouts;

public sealed class GridRow : ComponentBase, IDisposable
{
    [CascadingParameter]
    private Grid? Grid { get; set; }

    [Parameter]
    public Size Height { get; set; } = Size.Auto;

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        Grid?.Rows.Remove(this);
    }

    protected override void OnInitialized()
        => Grid?.Rows.Add(this);
}

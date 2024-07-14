using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

public abstract class DataGridColumn<TItem> : ComponentBase
{
    protected DataGridColumn()
    {
        CellContent = CreateCellContent();
        HeaderContent = CreateHeaderContent();
    }

    internal RenderFragment<TItem> CellContent { get; }

    [CascadingParameter]
    private DataGrid<TItem>? DataGrid { get; set; }

    internal RenderFragment HeaderContent { get; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public Size Width { get; set; } = Size.Auto;

    protected abstract RenderFragment<TItem> CreateCellContent();

    protected virtual RenderFragment CreateHeaderContent()
        => builder => builder.AddContent(sequence: 0, Title);

    protected override void OnInitialized()
        => DataGrid?.AddColumn(this);
}

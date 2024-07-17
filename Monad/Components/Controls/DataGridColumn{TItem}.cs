using Microsoft.AspNetCore.Components;
using System.ComponentModel;

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
    protected DataGrid<TItem>? DataGrid { get; private set; }

    internal RenderFragment HeaderContent { get; }

    [Parameter, Description("When virtualizing, is used to determine cell contents for not-yet-loaded data.")]
    public RenderFragment? Placeholder { get; set; }

    [Parameter, Description("Column title, shown in the grid's header row.")]
    public string? Title { get; set; }

    [Parameter, Description("Column width. Defaults to <code>Size.Auto</code>.")]
    public Size Width { get; set; } = Size.Auto;

    protected abstract RenderFragment<TItem> CreateCellContent();

    protected virtual RenderFragment CreateHeaderContent()
        => builder => builder.AddContent(sequence: 0, Title);

    protected override void OnInitialized()
        => DataGrid?.AddColumn(this);
}

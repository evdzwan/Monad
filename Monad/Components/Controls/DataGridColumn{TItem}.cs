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

    [Parameter, Description("When true, the cell can be edited when row is selected.")]
    public bool AllowEdit { get; set; }

    internal RenderFragment<(TItem Item, bool Active)> CellContent { get; }

    [CascadingParameter]
    private DataGrid<TItem>? DataGrid { get; set; }

    [Parameter, Description("Used as cell content when <code>AllowEdit</code> is true and row is selected.")]
    public RenderFragment<TItem>? EditContent { get; set; }

    internal RenderFragment HeaderContent { get; }

    [Parameter, Description("When virtualizing, is used to determine cell contents for not-yet-loaded data.")]
    public RenderFragment? Placeholder { get; set; }

    [Parameter, Description("Column title, shown in the grid's header row.")]
    public string? Title { get; set; }

    [Parameter, Description("Column width. Defaults to <code>Size.Auto</code>.")]
    public Size Width { get; set; } = Size.Auto;

    protected abstract RenderFragment<(TItem Item, bool Edit)> CreateCellContent();

    protected virtual RenderFragment CreateHeaderContent()
        => builder => builder.AddContent(sequence: 0, Title);

    protected override void OnInitialized()
        => DataGrid?.AddColumn(this);
}

using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Grid
{
    internal List<GridCell> Cells { get; } = [];

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    internal List<GridColumn> Columns { get; } = [];

    internal List<GridRow> Rows { get; } = [];

    private string GetCellStyle(GridCell cell)
        => $"grid-column: {cell.X + 1} / span {cell.SpanX}; grid-row: {cell.Y + 1} / span {cell.SpanY}";

    private string GetGridStyle()
        => $"grid-template-columns: {string.Join(' ', Columns.Select(c => c.GetTemplateDimension()))}; grid-template-rows: {string.Join(' ', Rows.Select(r => r.GetTemplateDimension()))}";
}

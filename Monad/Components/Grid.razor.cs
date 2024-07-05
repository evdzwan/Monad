using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Grid
{
    internal List<GridCell> Cells { get; } = [];

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    internal List<GridColumn> Columns { get; } = [];

    internal List<GridRow> Rows { get; } = [];

    private static Dictionary<string, object?> GetCellAttributes(GridCell cell) => new()
    {
        { "style", $"grid-column: {cell.X + 1} / span {cell.SpanX}; grid-row: {cell.Y + 1} / span {cell.SpanY}" }
    };

    private Dictionary<string, object?> GetGridAttributes() => new()
    {
        { "style",  $"grid-template-columns: {string.Join(' ', Columns.Select(c => c.GetTemplateDimension()))}; grid-template-rows: {string.Join(' ', Rows.Select(r => r.GetTemplateDimension()))}" }
    };
}

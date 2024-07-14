using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Controls;

public sealed class DataGridTemplateColumn<TItem> : DataGridColumn<TItem>
{
    [Parameter, EditorRequired, Description("Cell content.")]
    public required RenderFragment<TItem> ChildContent { get; set; }

    protected override RenderFragment<(TItem Item, bool Edit)> CreateCellContent()
        => row => builder => (row.Edit ? EditContent : ChildContent)?.Invoke(row.Item)(builder);
}

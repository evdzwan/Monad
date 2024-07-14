using Microsoft.AspNetCore.Components;

namespace Monad.Components.Controls;

public sealed class DataGridTemplateColumn<TItem> : DataGridColumn<TItem>
{
    [Parameter, EditorRequired]
    public required RenderFragment<TItem> ChildContent { get; set; }

    protected override RenderFragment<TItem> CreateCellContent()
        => item => builder => ChildContent(item)(builder);
}

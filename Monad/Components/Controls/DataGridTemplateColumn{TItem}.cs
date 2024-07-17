using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Monad.Components.Controls;

public class DataGridTemplateColumn<TItem> : DataGridColumn<TItem>
{
    [Parameter, EditorRequired, Description("Cell content.")]
    public required RenderFragment<TItem> ChildContent { get; set; }

    protected override RenderFragment<TItem> CreateCellContent()
        => item => builder => ChildContent(item)(builder);
}

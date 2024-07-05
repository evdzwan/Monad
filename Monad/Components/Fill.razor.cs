using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Fill
{
    [Parameter, EditorRequired]
    public required RenderFragment ChildContent { get; set; }
}

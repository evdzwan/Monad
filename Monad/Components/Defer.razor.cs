using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Defer
{
    [Parameter, EditorRequired]
    public required RenderFragment ChildContent { get; set; }
}

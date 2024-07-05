using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Stack
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public StackOrientation Orientation { get; set; } = StackOrientation.Vertical;

    private string GetStackClass()
        => $"stack-{Orientation.ToString().ToLowerInvariant()}";
}

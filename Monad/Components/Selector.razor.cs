﻿using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class Selector<TItem>
{
    private Selection<TItem> _selection;

    public Selector()
        => _selection = new(Selection, Multiple);

    [Parameter]
    public RenderFragment<ISelection<TItem>>? ChildContent { get; set; }

    [Parameter]
    public bool Multiple { get; set; }

    [Parameter]
    public ICollection<TItem> Selection { get; set; } = [];

    protected override void OnParametersSet()
        => _selection = new(Selection, Multiple);
}

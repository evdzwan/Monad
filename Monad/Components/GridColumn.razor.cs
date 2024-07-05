﻿using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class GridColumn
{
    [CascadingParameter]
    private Grid Grid { get; set; } = default!;

    [Parameter]
    public GridDimension? MinWidth { get; set; }

    [Parameter]
    public GridDimension Width { get; set; } = GridDimension.Auto;

    internal string GetTemplateDimension()
        => MinWidth is { } minWidth ? $"minmax({minWidth}, {Width})" : Width.ToString();

    protected override void OnInitialized()
        => Grid.Columns.Add(this);
}

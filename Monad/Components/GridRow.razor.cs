﻿using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class GridRow
{
    [CascadingParameter]
    private Grid Grid { get; set; } = default!;

    [Parameter]
    public GridDimension Height { get; set; } = GridDimension.Auto;

    [Parameter]
    public GridDimension? MinHeight { get; set; }

    internal string GetTemplateDimension()
        => MinHeight is { } minHeight ? $"minmax({minHeight}, {Height})" : Height.ToString();

    protected override void OnInitialized()
        => Grid.Rows.Add(this);
}

﻿using Microsoft.AspNetCore.Components;

namespace Demo.Components;

public partial class Example
{
    private string? Code { get; set; }

    [Parameter, EditorRequired]
    public required string Identifier { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await using var stream = GetType().Assembly.GetManifestResourceStream($"Demo.Examples.{Identifier}.razor");
        if (stream is { CanRead: true })
        {
            using var reader = new StreamReader(stream);
            Code = (await reader.ReadToEndAsync()).TrimEnd();
        }
    }
}

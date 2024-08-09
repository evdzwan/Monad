using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Monad.Components.Charts;

public abstract class Chart<TItem> : ComponentBase where TItem : notnull
{
    protected CultureInfo CurrentCulture => CultureInfo.CurrentCulture;

    [MemberNotNullWhen(true, nameof(Selection))]
    protected bool HasSelection => Selection is not null;

    protected CultureInfo InvariantCulture => CultureInfo.InvariantCulture;

    [Parameter, EditorRequired, Description("Fixed collection that determines the chart's items.")]
    public required IEnumerable<TItem> Items { get; set; }

    [Parameter, Description("Delegate used to specify the title of each item.")]
    public Func<TItem, string?> ItemTitle { get; set; } = item => item?.ToString();

    [Parameter, Description("Delegate used to specify the value of each item.")]
    public Func<TItem, double> ItemValue { get; set; } = item => (double)Convert.ChangeType(item, typeof(double))!;

    [CascadingParameter]
    private ISelection<TItem>? Selection { get; set; }

    [Parameter, Description("Item titles are visible when true. Value is <code>false</code> by default.")]
    public bool ShowTitles { get; set; }

    [Parameter, Description("Item values are visible when true. Value is <code>false</code> by default.")]
    public bool ShowValues { get; set; }

    protected void ActivateItem(TItem item)
        => Selection?.Activate(item);

    protected string GenerateRandomColor()
        => $"#{Random.Shared.Next(16):x}{Random.Shared.Next(16):x}{Random.Shared.Next(16):x}";

    protected bool IsItemActive(TItem item)
        => Selection?.IsActive(item) == true;

    [Description("Manually refresh the chart.")]
    public Task Refresh()
        => InvokeAsync(StateHasChanged);
}

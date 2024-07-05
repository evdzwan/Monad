using Microsoft.AspNetCore.Components;

namespace Monad.Components;

public partial class ComboBox<TItem>
{
    [Parameter]
    public TItem? CurrentItem { get; set; }

    [Parameter]
    public EventCallback<TItem?> CurrentItemChanged { get; set; }

    private string? CurrentItemValue { get; set; }

    [Parameter, EditorRequired]
    public required IEnumerable<TItem> Items { get; set; }

    [Parameter]
    public Func<TItem?, string?> ItemValue { get; set; } = item => item?.ToString();

    [Parameter]
    public bool Multiple { get; set; }

    [Parameter]
    public ICollection<TItem> Selection { get; set; } = [];

    private string?[] SelectionValue { get; set; } = [];

    protected override void OnParametersSet()
    {
        if (CurrentItem is { } item && !Selection.Contains(item))
        {
            Selection.Add(item);
        }

        SelectionValue = Selection.Select(ItemValue).ToArray();
        CurrentItemValue = SelectionValue.LastOrDefault();
    }

    private Task UpdateSelection()
    {
        if (Multiple)
        {
            CurrentItemValue = SelectionValue.LastOrDefault();
        }
        else if (CurrentItemValue is { } value && !SelectionValue.Contains(value))
        {
            SelectionValue = [.. SelectionValue, value];
        }

        Selection.Clear();
        SelectionValue.ToList().ForEach(value => Selection.Add(Items.First(item => ItemValue(item) == value)));
        CurrentItem = Selection.LastOrDefault();

        return CurrentItemChanged.InvokeAsync(CurrentItem);
    }
}

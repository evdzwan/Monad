using System.Collections.ObjectModel;

namespace Demo.Components.Pages.Components;

public partial class ComboBoxDemo
{
    private Item? CurrentItem { get; set; }

    private Item[] Items { get; } = Enumerable.Range(1, 10).Select(i => new Item($"Option {i}")).ToArray();

    private ObservableCollection<Item> Selection { get; } = [];

    protected override void OnInitialized()
    {
        CurrentItem = Items[5];
        Selection.Add(Items[2]);
        Selection.Add(Items[7]);
        Selection.CollectionChanged += (sender, e) => StateHasChanged();
    }

    private sealed record Item(string Value);
}

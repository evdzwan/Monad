namespace Monad;

internal sealed class DataListProvider<TItem>(string dataListId, IEnumerable<TItem> items) : IDataListProvider<TItem>
{
    public string DataListId { get; } = dataListId;

    public IEnumerable<TItem> Items { get; } = items;
}

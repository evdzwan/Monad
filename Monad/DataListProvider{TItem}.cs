namespace Monad;

internal sealed class DataListProvider<TItem>(string id, IEnumerable<TItem> items) : IDataListProvider<TItem>
{
    public string Id { get; } = id;

    public IEnumerable<TItem> Items { get; } = items;
}

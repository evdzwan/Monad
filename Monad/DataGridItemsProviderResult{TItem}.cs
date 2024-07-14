namespace Monad;

public readonly struct DataGridItemsProviderResult<TItem>
{
    private DataGridItemsProviderResult(IEnumerable<TItem> items, bool? reachedEnd, int? totalItemCount)
    {
        Items = items;
        ReachedEnd = reachedEnd;
        TotalItemCount = totalItemCount;
    }

    public DataGridItemsProviderResult(IEnumerable<TItem> items, bool reachedEnd) : this(items, reachedEnd, totalItemCount: null) { }

    public DataGridItemsProviderResult(IEnumerable<TItem> items, int totalItemCount) : this(items, reachedEnd: null, totalItemCount) { }

    public IEnumerable<TItem> Items { get; }

    public bool? ReachedEnd { get; }

    public int? TotalItemCount { get; }
}

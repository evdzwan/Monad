using System.Collections;

namespace Monad;

public interface IDataListProvider<TItem> : IDataListProvider
{
    [Description("Items that make up the list.")]
    new IEnumerable<TItem> Items { get; }

    IEnumerable IDataListProvider.Items => Items;
}

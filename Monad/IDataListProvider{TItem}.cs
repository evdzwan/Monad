using System.Collections;

namespace Monad;

public interface IDataListProvider<TItem> : IDataListProvider
{
    new IEnumerable<TItem> Items { get; }

    IEnumerable IDataListProvider.Items => Items;
}

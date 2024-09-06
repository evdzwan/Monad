using System.Collections;

namespace Monad;

public interface IDataListProvider
{
    [Description("Unique identifier.")]
    string DataListId { get; }

    [Description("Items that make up the list.")]
    IEnumerable Items { get; }
}

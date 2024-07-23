using System.Collections;

namespace Monad;

public interface IDataListProvider
{
    [Description("Unique identifier of the data list.")]
    string Id { get; }

    [Description("Items that make up the data list.")]
    IEnumerable Items { get; }
}

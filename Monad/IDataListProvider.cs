using System.Collections;

namespace Monad;

public interface IDataListProvider
{
    string DataListId { get; }

    IEnumerable Items { get; }
}

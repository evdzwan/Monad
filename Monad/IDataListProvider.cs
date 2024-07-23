using System.Collections;

namespace Monad;

public interface IDataListProvider
{
    string Id { get; }

    IEnumerable Items { get; }
}
